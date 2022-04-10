using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FleaMarket.Application.Interfaces;
using FleaMarket.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FleaMarket.Controllers;

[Authorize]
[ApiController]
[Route("trades")]
public class TradeController : ExtendedController
{
    private readonly ITradeService _service;
    private readonly IMapper _mapper;
    
    public TradeController(IMapper mapper, UserManager<IdentityUser> userManager, ITradeService service) : base(userManager)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<TradeDto>>> Get()
    {
        var user = await GetCurrentUser();
        var result = await _service.GetTradesByUser(user);
        return _mapper.Map<List<TradeDto>>(result);
    }

    [HttpPost("{id}/cancel")]
    public async Task<ActionResult<TradeDto>> Cancel(string id)
    {
        var trade = await _service.FindById(id);
        if (trade is null) return NotFound();

        trade = await _service.CancelTrade(trade);
        return trade is null ? BadRequest() : _mapper.Map<TradeDto>(trade);
    }

    [HttpPost("{id}/complete")]
    public async Task<ActionResult<TradeDto>> Complete(string id)
    {
        var trade = await _service.FindById(id);
        if (trade is null) return NotFound();

        trade = await _service.CompleteTrade(trade);
        return trade is null ? BadRequest() : _mapper.Map<TradeDto>(trade);
    }
}