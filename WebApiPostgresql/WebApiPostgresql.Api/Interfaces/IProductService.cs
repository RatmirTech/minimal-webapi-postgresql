using WebApiPostgresql.Api.Models;

namespace WebApiPostgresql.Api.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}
