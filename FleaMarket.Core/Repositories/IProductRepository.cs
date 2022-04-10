using System.Collections.Generic;
using System.Threading.Tasks;
using FleaMarket.Core.Models;

namespace FleaMarket.Core.Repositories;

public interface IProductRepository
{
    Task<Product?> FindAsync(string id);
    Task<List<Product>> GetManyAsync(string? saller = null);
    Task<Product> AddAsync(Product entity);
    Task RemoveAsync(Product entity);
}