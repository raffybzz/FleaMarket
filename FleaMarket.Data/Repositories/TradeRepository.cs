using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FleaMarket.Core.Models;
using FleaMarket.Core.Repositories;
using FleaMarket.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FleaMarket.Data.Repositories;

public class TradeRepository : ITradeRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public TradeRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Trade?> FindAsync(string id)
    {
        var entity = await _context.Products.FindAsync(id);
        return _mapper.Map<Trade>(entity);
    }
    
    public async Task<List<Trade>> GetManyAsync(string? assignerId = null)
    {
        var queryable = _context.Trades
            .AsNoTracking()
            .Include(x => x.Product)
            .Include(x => x.Customer) as IQueryable<DbTrade>;
        if (assignerId != null)
            queryable = queryable.Where(x => x.CustomerId == assignerId);
        var entities = await queryable.ToListAsync();

        return _mapper.Map<List<Trade>>(entities);
    }

    public async Task<Trade> AddAsync(Trade entity)
    {
        var dbEntity = _mapper.Map<DbTrade>(entity);
        _context.AttachRange(dbEntity.Customer, dbEntity.Product);
        var value = await _context.AddAsync(dbEntity);
        await _context.SaveChangesAsync();
        return _mapper.Map<Trade>(value.Entity);
    }

    public async Task<Trade> UpdateAsync(Trade entity)
    {
        var dbEntity = _context.Trades.SingleOrDefault(x => x.Id == entity.Id);
        _mapper.Map(entity, dbEntity);
        await _context.SaveChangesAsync();
        return _mapper.Map<Trade>(dbEntity);
    }
}