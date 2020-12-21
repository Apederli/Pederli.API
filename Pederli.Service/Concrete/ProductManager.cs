using Pederli.Data.UnitOfWork;
using Pederli.Entity;
using Pederli.Service.Abstract;
using System;
using System.Threading.Tasks;
using Pederli.Core.DataAccess.EntityFreamwork;
using Pederli.Data.DataAccess;

namespace Pederli.Service.Concrete
{
    public class ProductManager :ServiceManager<Product>, IProductService
    {
        public ProductManager(IUnitOfWork unitOfWork, IEntityRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
