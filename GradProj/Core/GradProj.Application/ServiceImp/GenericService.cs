using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.ServiceAbs;
using GradProj.Domain.Entities;
using GradProj.Domain.RepositoryAbs;

namespace GradProj.Application.ServiceImp
{
    public class GenericService<T> : IService<T> where T : BaseEntity
    {
        protected readonly IRepository<T> _repository;
        public GenericService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(T entity)
        {
           await _repository.AddAsync(entity);
        }

        public void DeleteAsync(Guid id)
        {
            _repository.DeleteAsync(id);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<T?> GetByIdAsync(Guid id)
        {
            return _repository.GetByIdAsync(id);
        }

        public async Task<List<T>> GetListGetWhere(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>>? include = null)
        {
           return  await _repository.GetListGetWhere(predicate, include);
        }

        public IEnumerable<T> GetSingleAsync(Func<T, bool> predicate)
        {
            return _repository.GetSingleAsync(predicate);
        }

        public void UpdateAsync(T entity)
        {
            _repository.UpdateAsync(entity);
        }
    }
}
