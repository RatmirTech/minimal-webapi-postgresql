using WebApiPostgresql.Api.Interfaces;
using WebApiPostgresql.Api.Models;

namespace WebApiPostgresql.Api.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _repository { get; set; }

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public List<Product> GetProducts()
        {
            return _repository.GetProducts();
        }
    }
    //public class ProductService : IProductService
    //{
    //    private IDbConnection _dbConnection;

    //    public ProductService(IDbConnection dbConnection)
    //    {
    //        _dbConnection = dbConnection;
    //    }

    //    public List<Product> GetProducts()
    //    {
    //        var list = _dbConnection.GetAll<Product>().ToList();
    //        return list;
    //    }
    //}
}
