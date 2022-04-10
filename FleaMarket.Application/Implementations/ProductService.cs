using System.Collections.Generic;
using System.Threading.Tasks;
using FleaMarket.Application.Interfaces;
using FleaMarket.Core.Models;
using FleaMarket.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace FleaMarket.Application.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly ITradeService _tradeService;

    public ProductService(IProductRepository repository, ITradeService tradeService)
    {
        _repository = repository;
        _tradeService = tradeService;
    }

    public Task<Product?> FindById(string id)
    {
        return _repository.FindAsync(id);
    }

    public Task<List<Product>> GetAllProducts()
    {
        return _repository.GetManyAsync();
    }

    public Task<List<Product>> GetProductsByUser(IdentityUser user)
    {
        return _repository.GetManyAsync(user.Id);
    }

    public Task DeleteProduct(Product product)
    {
        return _repository.RemoveAsync(product);
    }

    public async Task<Product?> CreateProduct(Product product)
    {
        try
        {
            return await _repository.AddAsync(product);
        }
        catch
        {
            return null;
        }
    }

    public Task<Trade?> BuyProduct(Product product, IdentityUser customer)
    {
        var trade = new Trade()
        {
            Product = product,
            Customer = customer,
            Status = TradeStatus.Active
        };

        return _tradeService.CreateTrade(trade);
    }
}