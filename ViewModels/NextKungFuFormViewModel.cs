using System.Reactive;
using System.Reactive.Linq;
using Interfaces;
using Models;
using ReactiveUI;

namespace ViewModels;

public class NextKungFuFormViewModel : ReactiveObject, INextKungFuFormViewModel
{
    private KungFuForm _nextForm = KungFuForm.Empty;

    public NextKungFuFormViewModel(IKungfuRandomizer randomizer)
    {
        GetNextForm = ReactiveCommand.Create<Unit, Unit>(_ =>
        {
            var nextForm = randomizer.NextRandomForm();
            NextForm = nextForm;
            return Unit.Default;
        });

        TrainToday = ReactiveCommand.Create<Unit, Unit>(form =>
        {
            NextForm.TrainedDates.Add(DateTimeOffset.Now);
            return Unit.Default;
        });
    }

    public KungFuForm NextForm
    {
        get => _nextForm;
        private set => this.RaiseAndSetIfChanged(ref _nextForm, value);
    }

    public ReactiveCommand<Unit, Unit> GetNextForm { get; }

    public ReactiveCommand<Unit, Unit> TrainToday { get; }
}