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
        GetNextForm = ReactiveCommand.Create<Unit, string>(_ => Guid.NewGuid().ToString("N"));
        GetNextForm.Do(nextFormText => NextForm = randomizer.NextRandomForm()).Subscribe();
    }

    public KungFuForm NextForm
    {
        get => _nextForm;
        private set => this.RaiseAndSetIfChanged(ref _nextForm, value);
    }

    public ReactiveCommand<Unit, string> GetNextForm { get; }
}