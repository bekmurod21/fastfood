using FastFood.Domain.Entities.Users;
using FastFood.Service.DTOs.LoginDto;
using FastFood.Service.Exceptions;
using FastFood.Service.Helpers;
using FastFood.Service.Interfaces.Authorizations;
using FastFood.Service.Interfaces.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FastFood.Service.Services.Users;

public class AuthService : IAuthService
{
    private readonly IUserService userService;
    private readonly IConfiguration configuration;
    private readonly IRoleService roleService;
    public AuthService(IUserService userService, IConfiguration configuration, IRoleService roleService)
    {
        this.userService = userService;
        this.configuration = configuration;
        this.roleService = roleService;
    }

    public async Task<LoginForResultDto> AuthenticateAsync(string email, string password)
    {
        var user = await this.userService.RetrieveByEmailAsync(email);
        if (user == null || !PasswordHelper.Verify(password, user.Password))
            throw new CustomException(400, "Email or password is incorrect");

        var role = await this.roleService.RetrieveByIdForAuthAsync(user.RoleId);
        user.Roles = role;
        return new LoginForResultDto
        {
            Token = GenerateToken(user)
        };
    }
    private string GenerateToken(User user)
    {
        var tokenHendler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
        var tokenDisctiptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Roles.Name.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName)
            }),
            Audience = configuration["JWT:Audience"],
            Issuer = configuration["JWT:Issuer"],
            IssuedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(double.Parse(configuration["JWT:Expire"])),
            SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHendler.CreateToken(tokenDisctiptor);
        return tokenHendler.WriteToken(token);
    }
}

