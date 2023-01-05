using Models;

namespace Interfaces;

public interface IRepository
{
    Task<IEnumerable<KungFuForm>> GetKungFuFormsAsync();
    
    Task PersistKungFuFormsAsync(IEnumerable<KungFuForm> forms);
}