using System.Reactive;
using ReactiveUI;

namespace ViewModels;

public interface INextKungFuFormViewModel
{
    string NextFormText { get; }

    public ReactiveCommand<Unit, string> GetNextForm { get; }
}