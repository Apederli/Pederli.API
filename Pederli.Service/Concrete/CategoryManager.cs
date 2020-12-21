using Pederli.Data.DataAccess;
using Pederli.Data.UnitOfWork;
using Pederli.Entity;
using Pederli.Service.Abstract;

namespace Pederli.Service.Concrete
{
    public class CategoryManager : ServiceManager<Category>, ICategoryService
    {
        public CategoryManager(IUnitOfWork unitOfWork, IEntityRepository<Category> repository) : base(unitOfWork, repository)
        {
        }
    }
}
