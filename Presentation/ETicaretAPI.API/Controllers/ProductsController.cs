﻿using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretAPI.API.Controllers       //Test işlemlerini burada hallediyoruz.
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        //readonly private IOrderWriteRepository _orderWriteRepository;
        //readonly private IOrderReadRepository _orderReadRepository;

        //readonly private ICustomerWriteRepository _customerWriteRepository;
        public ProductsController(
            IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository
            //IOrderWriteRepository orderWriteRepository,
            //ICustomerWriteRepository customerWriteRepository,
            //IOrderReadRepository orderReadRepository
            )
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            //_orderWriteRepository = orderWriteRepository;
            //_customerWriteRepository = customerWriteRepository;
            //_orderReadRepository = orderReadRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //False kullanmamızın sebebi track işlemine gerek duymadığımız için gereksiz track işlemini yapmasını engellememizdir.
            return Ok(_productReadRepository.GetAll(false));    
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            //False kullanmamızın sebebi track işlemine gerek duymadığımız için gereksiz track işlemini yapmasını engellememizdir.
            return Ok(await _productReadRepository.GetByIdAsync(id, false));
        }


        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            //Burada yaptığımız işlemi test amaçlı burada gerçekleştirdik. İlerleyen dönemde bu işlemleri ayrı bir yerden yöneteceğiz.
            await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock
            });
            await _productWriteRepository.SaveAsync();
            
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.Stock;
            product.Name = model.Name;
            product.Price = model.Price;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

    }
}
