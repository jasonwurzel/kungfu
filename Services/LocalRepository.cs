using FileHelpers;
using Interfaces;
using Models;

namespace Services;

public class LocalRepository : IRepository
{
    private readonly string _basePath;
    private readonly string _kungFuCsvFileName;

    public LocalRepository(string fileNameKungFuForms = "forms.csv", string basePath = "")
    {
        _kungFuCsvFileName = fileNameKungFuForms;
        _basePath = basePath;
    }

    public IEnumerable<KungFuForm> GetKungFuForms()
    {
        var engine = new FileHelperEngine<KungFuFormCsv>();
        var kungFuFormsCsv = engine.ReadFile(Path.Combine(_basePath, _kungFuCsvFileName));
        return kungFuFormsCsv.Select(csv => new KungFuForm(csv.Name));
    }

    [DelimitedRecord(";")]
    public class KungFuFormCsv
    {
        public string Name { get; set; } = String.Empty;
    }
}

