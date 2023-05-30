namespace WellMonitor.Core.Interfaces
{
    public interface IRepositoryBase<TEntity> : IDisposable
            where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id, bool asNoTracking = true);

        Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking = true);

        void Create(TEntity item); 

        void Update(TEntity item);

        void Delete(TEntity item);

        void CreateRange(IEnumerable<TEntity> entities);

        void UpdateRange(IEnumerable<TEntity> entities);

        void DeleteRange(IEnumerable<TEntity> entities);

        Task<IEnumerable<TEntity>> FindWithSpecificationPatternAsync(ISpecification<TEntity> specification, bool asNoTracking = true);
    }
}
