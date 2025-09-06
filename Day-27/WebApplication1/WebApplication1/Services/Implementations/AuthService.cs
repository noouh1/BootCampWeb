﻿using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using WebApplication1.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Dto;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace WebApplication1.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly JWT _jwt;
    public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IOptions<JWT> jwt)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _mapper = mapper;
        _jwt = jwt.Value;
    }
        public async Task<Response<AuthModel>> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName); 
            if (user is null)
            {
                return new Response<AuthModel>
                {
                    Message = "Invalid credentials",
                    StatusCode = HttpStatusCode.Unauthorized
                };
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
            {
                return new Response<AuthModel>
                {
                    Message = "Invalid credentials",
                    StatusCode = HttpStatusCode.Unauthorized
                };
            }

            var jwtSecurityToken = await CreateJwtToken(user);


            return new Response<AuthModel>
            {
                StatusCode = HttpStatusCode.OK,
                Data = new AuthModel
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault(),
                    UserName = user.UserName
                },
                Message = "Login successful"
            };
        }

        public async Task<Response<AuthModel>> Register(RegisterModel model)
        {
            if (string.IsNullOrEmpty(model.Email))
            {
                return new Response<AuthModel>
                {
                    Message = "Email cannot be null or empty",
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            if (string.IsNullOrEmpty(model.Role))
            {
                return new Response<AuthModel>
                {
                    Message = "Role cannot be null or empty",
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
            {
                return new Response<AuthModel>
                {
                    Message = "Email already exists",
                    StatusCode = HttpStatusCode.Conflict
                };
            }
            var user = _mapper.Map<ApplicationUser>(model);

            var result = await _userManager.CreateAsync(user, model.Password);
            


            if (!result.Succeeded)
            {
                var errors = string.Empty;
                errors += result.Errors.Select(x=>x.Description).ToString();
                return new Response<AuthModel>
                {
                    Message = errors,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            await _userManager.AddToRoleAsync(user , model.Role);

            var jwtSecurityToken = await CreateJwtToken(user);

            return new Response<AuthModel>
            {
                Message = "User created successfully",
                StatusCode = HttpStatusCode.OK,
                Data = new AuthModel
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    Role = model.Role,
                    UserName = user.UserName
                }
            };

        }


        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name , user.UserName),
                new Claim(ClaimTypes.NameIdentifier , user.Id),
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role , roles.FirstOrDefault())
            }
            .Union(userClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey , SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.ExpireDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    
}