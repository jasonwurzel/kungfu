using FileHelpers;
using Interfaces;
using Models;

namespace Services;

public class LocalRepository : IRepository
{
    private readonly string _basePath = String.Empty;
    private readonly string _kungFuCsvFileName = "forms.csv";
    public IEnumerable<KungFuForm> GetKungFuForms()
    {
        var engine = new FileHelperEngine<KungFuFormCsv>();
        var kungFuFormsCsv = engine.ReadFile(Path.Combine(_basePath, _kungFuCsvFileName));
        return kungFuFormsCsv.Select(csv => new KungFuForm(csv.Name));
    }

    public class KungFuFormCsv
    {
        public string Name { get; set; } = String.Empty;
    }
}

