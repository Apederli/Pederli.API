using Microsoft.EntityFrameworkCore;
using Pederli.Core.DataAccess.EntityFreamwork;
using Pederli.Data.Abstract;
using Pederli.Entity;
using System.Threading.Tasks;
using Pederli.Data.DataAccess;

namespace Pederli.Data.Concrete.EntityFreamwork
{
    public class CategoryDal : EntityFreamworkBase<Category> ,ICategoryDal
    {
        private DatabaseContext db {get=>_context as DatabaseContext;}

        public CategoryDal(DatabaseContext context) : base(context)
        {
        }


        public async Task<Category> GetWithProductByIdAsync(int categoryId)
        {
            return await db.Categories.Include(x => x.Products).SingleOrDefaultAsync(x => x.Id == categoryId);
        }
    }
}
