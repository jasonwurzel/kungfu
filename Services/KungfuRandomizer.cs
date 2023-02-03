using Interfaces;
using Models;

namespace Services;

public class KungFuRandomizer : IKungfuRandomizer
{
    private readonly Random _random;
    private readonly IReadOnlyCollection<KungFuForm> _kungFuForms;
    private readonly List<string> _usedForms = new();

    public KungFuRandomizer(IReadOnlyCollection<KungFuForm> kungFuForms)
    {
        _kungFuForms = kungFuForms;
        _random = new Random();
    }
    public KungFuForm NextRandomForm()
    {
        // of course, this algo can be Leetcode-style optimized. But we won't have more than some dozen forms, so it doesn't matter.
        int randomIndex = -1;

        var leastTrainedKungFuForms = takeLeastTrainedKungFuForms();
        var oldestNotTrainedKungFuForms = takeOldestNotTrainedKungFuForm(leastTrainedKungFuForms);

        if (!oldestNotTrainedKungFuForms.Any())
            return _kungFuForms.First();

        // if we used all from the current collection as a possible form, start again
        if (oldestNotTrainedKungFuForms.All(f => _usedForms.Contains(f.Name))) 
            _usedForms.Clear();

        // if there is any form in usedForms that is NOT in our current collection, start again. This would mean our current collection has changed.
        if (_usedForms.Any(formName => !oldestNotTrainedKungFuForms.Select(f => f.Name).Contains(formName))) 
            _usedForms.Clear();

        KungFuForm randomForm;
        do
        {
            randomIndex = _random.Next(0, oldestNotTrainedKungFuForms.Count);
            randomForm = oldestNotTrainedKungFuForms.ElementAt(randomIndex);
        } while (_usedForms.Any(used => used == randomForm.Name));

        _usedForms.Add(randomForm.Name);


        return randomForm;
    }

    private IReadOnlyCollection<KungFuForm> takeOldestNotTrainedKungFuForm(IReadOnlyCollection<KungFuForm> leastTrainedKungFuForms)
    {
        if (!leastTrainedKungFuForms.Any())
            return _kungFuForms;

        return leastTrainedKungFuForms
            .GroupBy(f =>
            {
                // MaxBy throws if empty...
                if (!f.TrainedDates.Any())
                    return DateTimeOffset.MinValue;

                return f.TrainedDates.MaxBy(dt => dt);
            })
            .MinBy(forms => forms.Key)
            ?.ToList() ?? _kungFuForms;
    }

    private IReadOnlyCollection<KungFuForm> takeLeastTrainedKungFuForms()
    {
        return _kungFuForms.GroupBy(f => f.TrainedDates.Count).MinBy(f => f.Key)?.ToList() ?? _kungFuForms;
    }
}