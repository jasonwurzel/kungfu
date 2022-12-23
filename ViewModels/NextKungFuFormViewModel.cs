using ReactiveUI;

namespace ViewModels;

public class NextKungFuFormViewModel : ReactiveObject, INextKungFuFormViewModel
{
    private string _nextFormText = String.Empty;

    public NextKungFuFormViewModel()
    {
        GetNextForm = ReactiveCommand.Create(() => NextFormText = Guid.NewGuid().ToString("N"));
    }

    public string NextFormText
    {
        get => _nextFormText;
        private set => this.RaiseAndSetIfChanged(ref _nextFormText, value);
    }

    public IReactiveCommand GetNextForm { get; }
}