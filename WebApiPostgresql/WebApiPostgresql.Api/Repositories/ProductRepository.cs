using Dapper.Contrib.Extensions;
using System.Data;
using WebApiPostgresql.Api.Interfaces;
using WebApiPostgresql.Api.Models;

namespace WebApiPostgresql.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private IDbConnection _dbConnection;

        public ProductRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<Product> GetProducts()
        {
            var list = _dbConnection.GetAll<Product>().ToList();
            return list;
        }
    }
}
