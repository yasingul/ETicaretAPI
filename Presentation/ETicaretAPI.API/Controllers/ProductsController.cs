using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        public async void Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() { Id = Guid.NewGuid(), Name="Product1", Price = 100, CreatedDay= DateTime.UtcNow, Stock = 50},
                new() { Id = Guid.NewGuid(), Name="Product2", Price = 160, CreatedDay= DateTime.UtcNow, Stock = 80},
                new() { Id = Guid.NewGuid(), Name="Product3", Price = 130, CreatedDay= DateTime.UtcNow, Stock = 20},
            });
            await _productWriteRepository.SaveAsync();
        }
    }
}
