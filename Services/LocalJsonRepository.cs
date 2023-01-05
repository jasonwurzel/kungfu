using System.Text.Json;
using Interfaces;
using Models;

namespace Services;

public class LocalJsonRepository : IRepository
{
    private readonly string _filePath;

    public LocalJsonRepository(string fileNameKungFuForms = "forms.json", string basePath = "")
    {
        _filePath = Path.Combine(basePath, fileNameKungFuForms);
    }

    public async Task<IEnumerable<KungFuForm>> GetKungFuFormsAsync()
    {
        // Path.Combine(_basePath, _kungFuFileName)
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
        
        return kungFuFormsJson.Select(csv => new KungFuForm(csv.Name));
    }

    public async Task PersistKungFuFormsAsync(IEnumerable<KungFuForm> forms)
    {
        await using var stream = File.Create(_filePath);
        var kungFuFormJsons = forms.Select(form => new KungFuFormJson(form.Name, form.TrainedDates.ToArray()));
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