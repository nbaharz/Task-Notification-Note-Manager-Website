using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GradProj.Domain.Entities;

namespace GradProj.Domain.RepositoryAbs
{
    public interface IRepository<T>where T : BaseEntity
    {
        IEnumerable<T> GetSingleAsync(Func<T, bool> predicate);
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(Guid id);

        Task AddAsync(T entity);

        void UpdateAsync(T entity);

        void DeleteAsync(Guid id);

        //Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);

    }
}
