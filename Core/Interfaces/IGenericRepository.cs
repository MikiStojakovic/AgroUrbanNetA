using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T?> GetEntityWithSpec(ISpecification<T> specification);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification);
        Task<TResult?> GetEntityWithSpec<TResult>(ISpecification<T, TResult> specification);
        Task<IReadOnlyList<TResult>> ListAsync<TResult>(ISpecification<T, TResult> specification);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> SaveAllAsync();
        bool Exists(Guid id);
        Task<int> CountAsync(ISpecification<T> specification);
    }
}