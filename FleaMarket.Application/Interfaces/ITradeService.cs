using System.Collections.Generic;
using System.Threading.Tasks;
using FleaMarket.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace FleaMarket.Application.Interfaces;

public interface ITradeService
{
    Task<Trade?> FindById(string id);
    Task<List<Trade>> GetTradesByUser(IdentityUser user);
    Task<Trade?> CreateTrade(Trade trade);
    Task<Trade?> CancelTrade(Trade trade);
    Task<Trade?> CompleteTrade(Trade trade);
}