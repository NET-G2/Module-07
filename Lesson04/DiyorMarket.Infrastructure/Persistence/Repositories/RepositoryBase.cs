using DiyorMarket.Domain.Common;
using DiyorMarket.Domain.Exceptions;
using DiyorMarket.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DiyorMarket.Infrastructure.Persistence.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly DiyorMarketDbContext _context;

        public RepositoryBase(DiyorMarketDbContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            var createdEntity = await _context.Set<T>().AddAsync(entity);

            return createdEntity.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await FindByIdAsync(id);

            _context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            var entities = await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();

            return entities;
        }

        public async Task<T> FindByIdAsync(int id)
        {
            var entity = await _context.Set<T>()
                .FindAsync(id);

            if (entity is null)
            {
                throw new EntityNotFoundException(
                    $"Entity {typeof(T)} with id: {id} not found.");
            }

            return entity;
        }

        public void UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
