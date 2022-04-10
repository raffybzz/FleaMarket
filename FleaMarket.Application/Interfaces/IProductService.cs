using System.Collections.Generic;
using System.Threading.Tasks;
using FleaMarket.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace FleaMarket.Application.Interfaces;

public interface IProductService
{
    Task<Product?> FindById(string id);
    Task<List<Product>> GetAllProducts();
    Task<List<Product>> GetProductsByUser(IdentityUser user);
    Task DeleteProduct(Product product);
    Task<Product?> CreateProduct(Product product);
    Task<Trade?> BuyProduct(Product product, IdentityUser customer);
}