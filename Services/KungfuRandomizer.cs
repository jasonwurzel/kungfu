using Interfaces;
using Models;
using System.Linq.Expressions;

namespace Services;

public class KungfuRandomizer : IKungfuRandomizer
{
    private readonly Random _random;
    private readonly IReadOnlyCollection<KungFuForm> _kungFuForms;
    private readonly List<int> _usedIndices = new();

    public KungfuRandomizer(IReadOnlyCollection<KungFuForm> kungFuForms)
    {
        _kungFuForms = kungFuForms;
        _random = new Random();
    }
    public KungFuForm NextRandomForm()
    {
        int randomIndex = -1;
        if (_usedIndices.Count == _kungFuForms.Count) 
            _usedIndices.Clear();
        do
        {
            randomIndex = _random.Next(0, _kungFuForms.Count);
        } while (_usedIndices.Any(used => used == randomIndex));

        _usedIndices.Add(randomIndex);

        var randomForm = _kungFuForms.ElementAt(randomIndex);

        return randomForm;
    }
}