using WebApplication1.Controllers.Base;
using WebApplication1.Dto;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApplication1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return Result(new Response<object>
                {
                    Data = ModelState,
                    StatusCode = HttpStatusCode.BadRequest
                });
            }
            var result = await _authService.Register(model);
            return Result(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return Result(new Response<object>
                {
                    Data = ModelState,
                    StatusCode = HttpStatusCode.BadRequest
                });
            }
            var result = await _authService.Login(model);
            return Result(result);
        }
    }
}