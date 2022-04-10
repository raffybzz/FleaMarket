using System.Collections.Generic;
using System.Threading.Tasks;
using FleaMarket.Core.Models;

namespace FleaMarket.Core.Repositories;

public interface ITradeRepository
{
    Task<Trade?> FindAsync(string id);
    Task<List<Trade>> GetManyAsync(string? assignerId = null);
    Task<Trade> AddAsync(Trade entity);
    Task<Trade> UpdateAsync(Trade entity);
}