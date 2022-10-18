using Lib.Data.GenericRepository;
namespace Lib.Data
{
    public interface IRepositoryFactory
    {
        IRepository Repository();
    }
}
