using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Pederli.Data.Abstract;

namespace Pederli.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductDal Products { get; }
        ICategoryDal Categories { get; }
        Task CommitAsync();

        void Commit();
    }
}
