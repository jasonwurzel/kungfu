using Interfaces;
using Models;

namespace Services;

public class KungfuRandomizer : IKungfuRandomizer
{
    private readonly Random _random;
    private readonly IReadOnlyCollection<KungFuForm> _kungFuForms;

    public KungfuRandomizer(IReadOnlyCollection<KungFuForm> kungFuForms)
    {
        _kungFuForms = kungFuForms;
        _random = new Random();
    }
    public KungFuForm NextRandomForm()
    {
        var randomIndex = _random.Next(0, _kungFuForms.Count - 1);
        var randomForm = _kungFuForms.ElementAt(randomIndex);
        return randomForm;
    }
}