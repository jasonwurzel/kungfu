using System.Collections.ObjectModel;
using System.Reactive;
using Models;
using ReactiveUI;

namespace Interfaces;

public interface INextKungFuFormViewModel
{
    KungFuForm NextForm { get; }

    ReactiveCommand<Unit, Unit> GetNextForm { get; }

    ReactiveCommand<Unit, Unit> TrainToday { get; }

    ObservableCollection<KungFuForm> KungFuForms { get; }
}