using System.Collections.ObjectModel;
using System.Reactive;
using Interfaces;
using Models;
using ReactiveUI;

namespace ViewModels;

public class NextKungFuFormViewModel : ReactiveObject, INextKungFuFormViewModel, IActivatableViewModel
{
    private KungFuForm _nextForm = null!;

    public NextKungFuFormViewModel(IKungfuRandomizer randomizer, IKungFuFormPersister persister, IReadOnlyCollection<KungFuForm> kungFuForms)
    {
        KungFuForms = new ObservableCollection<KungFuForm>(kungFuForms);
        GetNextForm = ReactiveCommand.Create<Unit, Unit>(_ =>
        {
            var nextForm = randomizer.NextRandomForm();
            NextForm = nextForm;
            return Unit.Default;
        });

        TrainToday = ReactiveCommand.CreateFromTask<Unit, Unit>(async form =>
        {
            NextForm.TrainedDates.Add(DateTimeOffset.Now);
            await persister.PersistKungFuFormsAsync();
            return Unit.Default;
        });
    }

    public KungFuForm NextForm
    {
        get => _nextForm;
        set => this.RaiseAndSetIfChanged(ref _nextForm, value);
    }

    public ReactiveCommand<Unit, Unit> GetNextForm { get; }

    public ReactiveCommand<Unit, Unit> TrainToday { get; }

    public ObservableCollection<KungFuForm> KungFuForms { get; }

    public ViewModelActivator Activator { get; } = new();
}