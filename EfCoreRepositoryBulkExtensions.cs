using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Repositories;

namespace Des.EntityFrameworkCore.Extensions
{
    public static class EfCoreRepositoryBulkExtensions
    {
        public static void BulkInsert<TEntity, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository, IList<TEntity> entities, BulkConfig bulkConfig = null, Action<decimal> progress = null) where TEntity : class, IEntity<TPrimaryKey>
        {
            DbContextBulkTransaction.Execute(repository.GetDbContext(), entities, OperationType.Insert, bulkConfig, progress);
        }
        public static void BulkInsertOrUpdate<TEntity, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository, IList<TEntity> entities, BulkConfig bulkConfig = null, Action<decimal> progress = null) where TEntity : class, IEntity<TPrimaryKey>
        {
            DbContextBulkTransaction.Execute(repository.GetDbContext(), entities, OperationType.InsertOrUpdate, bulkConfig, progress);
        }

        public static void BulkUpdatee<TEntity, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository, IList<TEntity> entities, BulkConfig bulkConfig = null, Action<decimal> progress = null) where TEntity : class, IEntity<TPrimaryKey>
        {
            DbContextBulkTransaction.Execute(repository.GetDbContext(), entities, OperationType.Update, bulkConfig, progress);
        }

        public static void BulkDelete<TEntity, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository, IList<TEntity> entities, BulkConfig bulkConfig = null, Action<decimal> progress = null) where TEntity : class, IEntity<TPrimaryKey>
        {
            DbContextBulkTransaction.Execute(repository.GetDbContext(), entities, OperationType.Delete, bulkConfig, progress);
        }

        // Async methods

        public static Task BulkInsertAsync<TEntity, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository, IList<TEntity> entities, BulkConfig bulkConfig = null, Action<decimal> progress = null) where TEntity : class, IEntity<TPrimaryKey>
        {
            return DbContextBulkTransaction.ExecuteAsync(repository.GetDbContext(), entities, OperationType.Insert, bulkConfig, progress);
        }

        public static Task BulkInsertOrUpdateAsync<TEntity, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository, IList<TEntity> entities, BulkConfig bulkConfig = null, Action<decimal> progress = null) where TEntity : class, IEntity<TPrimaryKey>
        {
            return DbContextBulkTransaction.ExecuteAsync(repository.GetDbContext(), entities, OperationType.InsertOrUpdate, bulkConfig, progress);
        }

        public static Task BulkUpdateAsync<TEntity, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository, IList<TEntity> entities, BulkConfig bulkConfig = null, Action<decimal> progress = null) where TEntity : class, IEntity<TPrimaryKey>
        {
            return DbContextBulkTransaction.ExecuteAsync(repository.GetDbContext(), entities, OperationType.Update, bulkConfig, progress);
        }

        public static Task BulkDeleteAsync<TEntity, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository, IList<TEntity> entities, BulkConfig bulkConfig = null, Action<decimal> progress = null) where TEntity : class, IEntity<TPrimaryKey>
        {
            return DbContextBulkTransaction.ExecuteAsync(repository.GetDbContext(), entities, OperationType.Delete, bulkConfig, progress);
        }
    }
}
