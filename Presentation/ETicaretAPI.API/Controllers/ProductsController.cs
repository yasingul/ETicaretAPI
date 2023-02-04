using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
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
        public async Task Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new() { Id = Guid.NewGuid(), Name="Product1", Price = 100, CreatedDay= DateTime.UtcNow, Stock = 50},
            //    new() { Id = Guid.NewGuid(), Name="Product2", Price = 160, CreatedDay= DateTime.UtcNow, Stock = 80},
            //    new() { Id = Guid.NewGuid(), Name="Product3", Price = 130, CreatedDay= DateTime.UtcNow, Stock = 20},
            //});
            //await _productWriteRepository.SaveAsync();

            //Burada ki sorgu tracking mekanizmasıyla takip edileceği için değişiklik DB'ye yansır.
            Product p = await _productReadRepository.GetByIdAsync("268733b5-a565-434d-a579-5eba1a4928f8");
            p.Name = "Kalem";
            await _productWriteRepository.SaveAsync();
            //False yaptığımız için bu değişiklik tracking ile takip edilmeyeceğinden DB'ye yansımaz.
            Product p = await _productReadRepository.GetByIdAsync("81e75cc4-e886-40e2-badc-29cd836a34ad", false);
            p.Name = "Kılıç";
            await _productWriteRepository.SaveAsync();

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
