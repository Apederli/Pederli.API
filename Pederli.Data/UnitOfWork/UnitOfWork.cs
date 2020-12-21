using Pederli.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Pederli.Data.Concrete.EntityFreamwork;

namespace Pederli.Data.UnitOfWork
{
    public class UnitOfWork :IUnitOfWork
    {
        private DatabaseContext _db;
        private ProductDal _productDal;
        private CategoryDal _categoryDal;

        public UnitOfWork( DatabaseContext db)
        {
            _db = db;
        }

        public IProductDal Products => _productDal ??= new ProductDal(_db);

        public ICategoryDal Categories => _categoryDal ??= new CategoryDal(_db);

        public async Task CommitAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Commit()
        {
            _db.SaveChanges();
        }
    }
}
