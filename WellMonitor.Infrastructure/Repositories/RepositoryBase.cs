using Microsoft.EntityFrameworkCore;
using WellMonitor.Core.Interfaces;
using WellMonitor.Core.Specifications;

namespace WellMonitor.Infrastructure.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        protected readonly ApplicationDbContext Context;

        protected readonly DbSet<TEntity> DbSet;

        public RepositoryBase(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }  

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking = true) =>
            asNoTracking ? await DbSet.AsNoTracking().ToListAsync() : await DbSet.ToListAsync();

        public virtual async Task<TEntity> GetByIdAsync(int id, bool asNoTracking = true)
        {
            return asNoTracking ? await DbSet.Where(e => e.Id == id).AsNoTracking().FirstOrDefaultAsync() :
                await DbSet.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public virtual void Create(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException($"{nameof(entity)} must be initialized");

            DbSet.Add(entity);
        }


        public virtual void Update(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException($"{nameof(entity)} must be initialized");

            DbSet.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException($"{nameof(entity)} must be initialized");

            DbSet.Remove(entity);
        }

        public virtual void CreateRange(IEnumerable<TEntity> entities)
        {
            if (entities is null)
                throw new ArgumentNullException($"{nameof(entities)} must be initialized");

            DbSet.AddRange(entities);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            if (entities is null)
                throw new ArgumentNullException($"{nameof(entities)} must be initialized");

            DbSet.UpdateRange(entities);
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            if (entities is null)
                throw new ArgumentNullException($"{nameof(entities)} must be initialized");

            DbSet.RemoveRange(entities);
        }

        public virtual async Task<IEnumerable<TEntity>> FindWithSpecificationPatternAsync(ISpecification<TEntity> specification, bool asNoTracking = true) 
        {
            if (specification is null)
                throw new ArgumentNullException();
            if(asNoTracking)
                return await SpecificationEvaluator<TEntity>.GetQuery(Context.Set<TEntity>().AsQueryable().AsNoTracking(), specification).ToListAsync();

            return await SpecificationEvaluator<TEntity>.GetQuery(Context.Set<TEntity>().AsQueryable(), specification).ToListAsync();
        }

        void IDisposable.Dispose() => Context.Dispose();     
    }
}
