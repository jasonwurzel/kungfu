using ReactiveUI;

namespace ViewModels;

public interface INextKungFuFormViewModel
{
    string NextFormText { get; }

    public IReactiveCommand GetNextForm { get; }
}