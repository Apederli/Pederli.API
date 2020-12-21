using Pederli.Entity;
using System.Threading.Tasks;
using Pederli.Data.DataAccess;

namespace Pederli.Data.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
