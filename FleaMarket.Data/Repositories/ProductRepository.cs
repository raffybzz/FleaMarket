using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FleaMarket.Core.Models;
using FleaMarket.Core.Repositories;
using FleaMarket.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FleaMarket.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ProductRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Product?> FindAsync(string id)
    {
        var entity = await _context.Products.FindAsync(id);
        return _mapper.Map<Product>(entity);
    }

    public async Task<List<Product>> GetManyAsync(string? saller = null)
    {
        var queryable = _context.Products
            .AsNoTracking()
            .Include(x => x.Saller) as IQueryable<DbProduct>;
        if (saller != null)
            queryable = queryable.Where(x => x.SallerId == saller);
        var entities = await queryable.ToListAsync();

        return _mapper.Map<List<Product>>(entities);
    }

    public async Task<Product> AddAsync(Product entity)
    {
        var dbEntity = _mapper.Map<DbProduct>(entity);
        var value = await _context.AddAsync(dbEntity);
        await _context.SaveChangesAsync();
        return _mapper.Map<Product>(value.Entity);
    }

    public async Task RemoveAsync(Product entity)
    {
        var dbEntity = await _context.Products.FindAsync(entity.Id);
        _context.Remove(dbEntity);
        await _context.SaveChangesAsync();
    }
}