using Microsoft.EntityFrameworkCore;
using WebApiPostgresql.Api.Models;

namespace WebApiPostgresql.Api.Interfaces
{
    public interface IDbContext
    {
        public DbSet<Product> Products { get; }

        /// <summary>
        /// Сохранить изменения единицы работы
        /// </summary>
        /// <param name="cancellationToken">Токен отмены запроса</param>
        /// <returns>-</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Сохранить изменения единицы работы
        /// </summary>
        /// <returns>-</returns>
        int SaveChanges();
    }
}
