using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FleaMarket.Application.Interfaces;
using FleaMarket.Core.Models;
using FleaMarket.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FleaMarket.Controllers;

[Authorize]
[ApiController]
[Route("/")]
public class ProductController : ExtendedController
{
    private readonly IProductService _service;
    private readonly IMapper _mapper;

    public ProductController(IProductService service, UserManager<IdentityUser> userManager, IMapper mapper) : base(userManager)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("account/products")]
    public async Task<ActionResult<List<ProductDto>>> GetMine()
    {
        var user = await GetCurrentUser();
        var product = await _service.GetProductsByUser(user);
        return _mapper.Map<List<ProductDto>>(product);
    }

    [HttpGet("products")]
    public async Task<ActionResult<List<ProductDto>>> GetMany()
    {
        var product = await _service.GetAllProducts();
        return _mapper.Map<List<ProductDto>>(product);
    }

    [HttpDelete("products/{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        var product = await _service.FindById(id);
        if (product is null) return NotFound();

        await _service.DeleteProduct(product);
        return Ok();
    }

    [HttpGet("products/{id}/buy")]
    public async Task<ActionResult<TradeDto>> Buy(string id)
    {
        var product = await _service.FindById(id);
        if (product is null) return NotFound();
        
        var trade = await _service.BuyProduct(product, await GetCurrentUser());
        return trade is null ? BadRequest() : _mapper.Map<TradeDto>(trade);
    }

    [HttpPost("products")]
    public async Task<ActionResult<ProductDto>> Create(ProductCreateDto model)
    {
        var product = _mapper.Map<Product>(model);
        product.Saller = await GetCurrentUser();

        product = await _service.CreateProduct(product);
        return product is null ? BadRequest() : _mapper.Map<ProductDto>(product);
    }
}