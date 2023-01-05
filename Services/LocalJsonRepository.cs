using System.Text.Json;
using Interfaces;
using Models;

namespace Services;

public class LocalJsonRepository : IRepository
{
    private readonly string _basePath;
    private readonly string _kungFuFileName;
    private readonly string _filePath;

    public LocalJsonRepository(string fileNameKungFuForms = "forms.json", string basePath = "")
    {
        _kungFuFileName = fileNameKungFuForms;
        _basePath = basePath;
        _filePath = Path.Combine(_basePath, _kungFuFileName);
    }

    public async Task<IEnumerable<KungFuForm>> GetKungFuForms()
    {
        // Path.Combine(_basePath, _kungFuFileName)
        using StreamReader reader = new StreamReader(_filePath);
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

    public async Task PersistKungFuForms(IEnumerable<KungFuForm> forms)
    {
        await using var stream = File.Create(_filePath);
        var kungFuFormJsons = forms.Select(form => new KungFuFormJson(form.Name, form.TrainedDates));
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