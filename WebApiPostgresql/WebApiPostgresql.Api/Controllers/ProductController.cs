using Microsoft.AspNetCore.Mvc;
using WebApiPostgresql.Api.Interfaces;
using WebApiPostgresql.Api.Models;

namespace WebApiPostgresql.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("GetProductsSer")]
        public List<Product> GetProductsSer()
        {
            var list = _productService.GetProducts();
            return list;
        }
    }
}
