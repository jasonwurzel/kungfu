using Models;

namespace Interfaces;

public interface IRepository
{
    IEnumerable<KungFuForm> GetKungFuForms();
}