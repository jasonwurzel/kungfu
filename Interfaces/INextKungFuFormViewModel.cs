using System.Reactive;
using Models;
using ReactiveUI;

namespace Interfaces;

public interface INextKungFuFormViewModel
{
    KungFuForm NextForm { get; }

    public ReactiveCommand<Unit, string> GetNextForm { get; }
}