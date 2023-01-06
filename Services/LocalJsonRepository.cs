using System.Text.Json;
using Interfaces;
using Models;

namespace Services;

public class LocalJsonRepository : IRepository
{
    private readonly string _filePath;
    private List<KungFuForm> _kungFuForms = new();

    public LocalJsonRepository(string fileNameKungFuForms = "forms.json", string basePath = "")
    {
        _filePath = Path.Combine(basePath, fileNameKungFuForms);
    }

    public IReadOnlyCollection<KungFuForm> KungFuForms
    {
        get
        {
            return _kungFuForms;
        }
    }

    public async Task InitializeAsync()
    {
        // this is a conscious decision. We could of course build it in a way where it is ensured that the forms are loaded before they are requested. 
        // (calling an unawaited init task in the ctor and waiting for it to finish before returning the kungfu forms, for example)
        // but as I am the only developer in this project, let's not overengineer...
        using var reader = new StreamReader(_filePath);
        var json = await reader.ReadToEndAsync();
        var kungFuFormsJson = new List<KungFuFormJson>();
        try
        {
            kungFuFormsJson = JsonSerializer.Deserialize<List<KungFuFormJson>>(json);
        }
        catch (Exception e)
        {
            // TODO notify user
            Console.WriteLine(e);
        }

        kungFuFormsJson ??= new List<KungFuFormJson>();
        
        _kungFuForms = kungFuFormsJson.Select(k => new KungFuForm(k.Name, k.TrainedDates)).ToList();
    }

    public async Task PersistKungFuFormsAsync()
    {
        await using var stream = File.Create(_filePath);
        var kungFuFormJsons = _kungFuForms.Select(form => new KungFuFormJson(form.Name, form.TrainedDates.ToArray()));
        await JsonSerializer.SerializeAsync(stream, kungFuFormJsons);
    }

    public class KungFuFormJson
    {
        public string Name { get; }
        public DateTimeOffset[] TrainedDates { get; }

        public KungFuFormJson(string name, DateTimeOffset[] trainedDates)
        {
            Name = name;
            TrainedDates = trainedDates;
        }
    }
}