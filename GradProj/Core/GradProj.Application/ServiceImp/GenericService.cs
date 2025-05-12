using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.ServiceAbs.Service;
using GradProj.Domain.Entities;
using GradProj.Domain.RepositoryAbs;

namespace GradProj.Application.ServiceImp
{
    public class GenericService<T> : IService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;
        public GenericService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(T entity)
        {
           await _repository.AddAsync(entity);
        }

        public void DeleteAsync(int id)
        {
            _repository.DeleteAsync(id);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<T?> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
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
