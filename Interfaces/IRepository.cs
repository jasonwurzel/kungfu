using Models;

namespace Interfaces;

public interface IRepository
{
    Task InitializeAsync();
    
    Task PersistKungFuFormsAsync();

    IReadOnlyCollection<KungFuForm> KungFuForms { get; }
}