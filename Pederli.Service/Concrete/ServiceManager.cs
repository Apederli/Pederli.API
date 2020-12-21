using Pederli.Data.UnitOfWork;
using Pederli.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Pederli.Core.DataAccess.EntityFreamwork;
using Pederli.Data.DataAccess;

namespace Pederli.Service.Concrete
{
    public class ServiceManager<TEntity> : IService<TEntity> where TEntity : class
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IEntityRepository<TEntity> _repository;

        public ServiceManager(IUnitOfWork unitOfWork, IEntityRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<TEntity> GetById(int id)
        {
           return await _repository.GetById(id);
        }

        public async Task<IEnumerable<TEntity>> GetList()
        {
            return await _repository.GetList();
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.Where(predicate);
        }

        public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.SingleOrDefault(predicate);
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _repository.Add(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entities)
        {
            await _repository.AddRange(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
           _repository.DeleteRange(entities);
           _unitOfWork.Commit();
        }

        public  TEntity Update(TEntity entity)
        {
           TEntity updateEntity= _repository.Update(entity);
            _unitOfWork.Commit();
            return updateEntity;
        }
    }
}
