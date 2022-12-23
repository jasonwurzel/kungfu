using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;

namespace ViewModels;

public class NextKungFuFormViewModel : ReactiveObject, INextKungFuFormViewModel
{
    private string _nextFormText = String.Empty;

    public NextKungFuFormViewModel()
    {
        GetNextForm = ReactiveCommand.Create<Unit, string>(_ => Guid.NewGuid().ToString("N"));
        GetNextForm.Do(nextFormText => NextFormText = nextFormText).Subscribe();
    }

    public string NextFormText
    {
        get => _nextFormText;
        private set => this.RaiseAndSetIfChanged(ref _nextFormText, value);
    }

    public ReactiveCommand<Unit, string> GetNextForm { get; }
}