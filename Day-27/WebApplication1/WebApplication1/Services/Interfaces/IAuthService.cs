using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces;

public interface IAuthService
{
    public Task<Response<AuthModel>> Register(RegisterModel model);
    public Task<Response<AuthModel>> Login(LoginModel model);
}