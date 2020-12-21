using Microsoft.EntityFrameworkCore;
using Pederli.Data.Abstract;
using Pederli.Data.DataAccess;
using Pederli.Entity;
using System.Threading.Tasks;

namespace Pederli.Data.Concrete.EntityFreamwork
{
    public class ProductDal : EntityFreamworkBase<Product>, IProductDal
    {
        private DatabaseContext db {get =>_context as DatabaseContext;}
        public ProductDal(DatabaseContext context) : base(context)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await db.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == productId);
        }
    }
}
