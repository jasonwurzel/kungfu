using Interfaces;
using ReactiveUI;

namespace ViewModels;

public class MainWindowViewModel : ReactiveObject, IMainWindowViewModel
{
    public INextKungFuFormViewModel NextKungFuFormViewModel { get; }

    public MainWindowViewModel(INextKungFuFormViewModel nextKungFuFormViewModel)
    {
        NextKungFuFormViewModel = nextKungFuFormViewModel;
    }
}