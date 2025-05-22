using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Domain.Entities;

namespace GradProj.Application.ServiceAbs
{
    public interface IService<T> where T : BaseEntity
    {
        IEnumerable<T> GetSingleAsync(Func<T, bool> predicate);
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(int id);

        Task AddAsync(T entity);

        void UpdateAsync(T entity);

        void DeleteAsync(int id);

    }
}
