using WebApiPostgresql.Api.Models;

namespace WebApiPostgresql.Api.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
    }
}
