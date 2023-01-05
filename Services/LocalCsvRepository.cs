using FileHelpers;
using Interfaces;
using Models;

namespace Services;

public class LocalCsvRepository : IRepository
{
    private readonly string _filePath;

    public LocalCsvRepository(string fileNameKungFuForms = "forms.csv", string basePath = "")
    {
        _filePath = Path.Combine(basePath, fileNameKungFuForms);
    }

    public Task<IEnumerable<KungFuForm>> GetKungFuForms()
    {
        var engine = new FileHelperEngine<KungFuFormCsv>();
        var kungFuFormsCsv = engine.ReadFile(_filePath);
        return Task.FromResult(kungFuFormsCsv.Select(csv => new KungFuForm(csv.Name)));
    }

    public Task PersistKungFuForms(IEnumerable<KungFuForm> forms)
    {
        var engine = new FileHelperEngine<KungFuFormCsv>();
        engine.WriteFile(_filePath, forms.Select(form => new KungFuFormCsv {Name = form.Name}));

        return Task.CompletedTask;
    }

    [DelimitedRecord(";")]
    private class KungFuFormCsv
    {
        public string Name { get; set; } = String.Empty;
    }
}