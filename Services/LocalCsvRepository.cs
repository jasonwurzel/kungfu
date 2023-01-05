using FileHelpers;
using Interfaces;
using Models;

namespace Services;

public class LocalCsvRepository : IRepository
{
    private readonly string _basePath;
    private readonly string _kungFuCsvFileName;

    public LocalCsvRepository(string fileNameKungFuForms = "forms.csv", string basePath = "")
    {
        _kungFuCsvFileName = fileNameKungFuForms;
        _basePath = basePath;
    }

    public Task<IEnumerable<KungFuForm>> GetKungFuForms()
    {
        var engine = new FileHelperEngine<KungFuFormCsv>();
        var kungFuFormsCsv = engine.ReadFile(Path.Combine(_basePath, _kungFuCsvFileName));
        return Task.FromResult(kungFuFormsCsv.Select(csv => new KungFuForm(csv.Name)));
    }

    [DelimitedRecord(";")]
    private class KungFuFormCsv
    {
        public string Name { get; set; } = String.Empty;
    }
}