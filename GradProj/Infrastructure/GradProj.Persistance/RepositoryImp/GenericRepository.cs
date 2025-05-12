using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Domain.Entities;
using GradProj.Domain.RepositoryAbs;
using GradProj.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;


namespace GradProj.Domain.RepositoryConcretes
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly GradProjDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(GradProjDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            _dbContext.SaveChanges();
        }

        public async void DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
            else 
            {
                throw new NotImplementedException();
            }
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id) // Task<T?> konulabilir
        {
            return await _dbSet.FindAsync(id);
        }

        public IEnumerable<T> GetSingleAsync(Func<T, bool> predicate)
        {
            return _dbSet.AsQueryable().Where(predicate).ToList();
        }

        public void UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
