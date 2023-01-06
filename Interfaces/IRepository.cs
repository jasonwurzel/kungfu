using Models;

namespace Interfaces;

public interface IRepository : IKungFuFormPersister
{
    Task InitializeAsync();
    
    IReadOnlyCollection<KungFuForm> KungFuForms { get; }
}

public interface IKungFuFormPersister
{
    Task PersistKungFuFormsAsync();
}