using System.Text.Json;
using Interfaces;
using Models;

namespace Services;

public class LocalJsonRepository : IRepository
{
    private readonly string _basePath;
    private readonly string _kungFuFileName;

    public LocalJsonRepository(string fileNameKungFuForms = "forms.json", string basePath = "")
    {
        _kungFuFileName = fileNameKungFuForms;
        _basePath = basePath;
    }

    public async Task<IEnumerable<KungFuForm>> GetKungFuForms()
    {
        // Path.Combine(_basePath, _kungFuFileName)
        using StreamReader reader = new StreamReader(Path.Combine(_basePath, _kungFuFileName));
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

    public class KungFuFormJson
    {
        public string Name { get; set; } = String.Empty;
    }
}