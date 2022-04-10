using System.Threading.Tasks;
using AutoMapper;
using FleaMarket.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FleaMarket.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ExtendedController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IMapper _mapper;

        public AccountController(UserManager<IdentityUser> userManager, IMapper mapper, SignInManager<IdentityUser> signInManager) : base(userManager)
        {
            this._mapper = mapper;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto model)
        {
            var user = _mapper.Map<IdentityUser>(model);
            var result = await UserManager.CreateAsync(user, model.Password);
            return result.Succeeded ? Ok(_mapper.Map<UserDto>(user)) : BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentAccount()
        {
            var user = await GetCurrentUser();
            return _mapper.Map<UserDto>(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto dto)
        {
            var user = await UserManager.FindByNameAsync(dto.Username);
            if (user == null) return NotFound();

            var passwordOk = await UserManager.CheckPasswordAsync(user, dto.Password);
            if (!passwordOk) return BadRequest();

            await _signInManager.SignInAsync(user, true);
            return Ok();
        }
    }
}