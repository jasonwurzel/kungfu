using Models;

namespace Interfaces;

public interface IRepository
{
    Task<IEnumerable<KungFuForm>> GetKungFuForms();
    
    Task PersistKungFuForms(IEnumerable<KungFuForm> forms);
}