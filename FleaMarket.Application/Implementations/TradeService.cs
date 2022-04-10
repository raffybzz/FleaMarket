using System.Collections.Generic;
using System.Threading.Tasks;
using FleaMarket.Application.Interfaces;
using FleaMarket.Core.Models;
using FleaMarket.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace FleaMarket.Application.Implementations;

public class TradeService : ITradeService
{
    private readonly ITradeRepository _repository;

    public TradeService(ITradeRepository repository)
    {
        _repository = repository;
    }

    public Task<Trade?> FindById(string id)
    {
        return _repository.FindAsync(id);
    }

    public Task<List<Trade>> GetTradesByUser(IdentityUser user)
    {
        return _repository.GetManyAsync(user.Id);
    }

    public async Task<Trade?> CreateTrade(Trade trade)
    {
        try
        {
            return await _repository.AddAsync(trade);
        }
        catch
        {
            return null;
        }
    }

    public async Task<Trade?> CancelTrade(Trade trade)
    {
        trade.Status = TradeStatus.Cancel;
        try
        {
            return await _repository.UpdateAsync(trade);
        }
        catch
        {
            return null;
        }
    }

    public async Task<Trade?> CompleteTrade(Trade trade)
    {
        trade.Status = TradeStatus.Completed;
        try
        {
            return await _repository.UpdateAsync(trade);
        }
        catch
        {
            return null;
        }
    }
}