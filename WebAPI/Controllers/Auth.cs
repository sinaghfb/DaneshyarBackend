using Domain.Contracts.Auth;
using Domain.DTOs.Auth.Request;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IAuthApplication _authApplication;

        public Auth(IConfiguration config, IAuthApplication authApplication)
        {
            _configuration = config;
            _authApplication = authApplication;
        }
        [HttpPut]
        public async Task<IActionResult> SignIn(NewUserRegisterRequest user)
        {
            SignInResponse response = new();

            response.user= await _authApplication.NewUserRegister(user);
            if (response.user.Status== ResponseState.Success)
            {
                //create claims details based on the user information
                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", response.user.UserId),
                        new Claim("UserAccessLevel",response.user.UserAccessLevel.ToString() ),
                        new Claim("PersonId", response.user.PersonId),
                        new Claim("UserName", response.user.UserName),
                        new Claim("FullName", response.user.FullName),
                        new Claim("NationalNo", response.user.NationalNo),


                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: signIn);
                response.accessToken = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(response);
            }
            else
            {
                return Unauthorized(response);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequest user)
        {
            SignInResponse response = new();
            response.user = await _authApplication.UserLogin(user);
            if (response.user.Status == ResponseState.Success)
            {
                //create claims details based on the user information
                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", response.user.UserId),
                        new Claim("UserAccessLevel",response.user.UserAccessLevel.ToString() ),
                        new Claim("PersonId", response.user.PersonId),
                        new Claim("UserName", response.user.UserName),
                        new Claim("FullName", response.user.FullName),
                        new Claim("NationalNo", response.user.NationalNo),


                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: signIn);
                response.accessToken = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(response);
            }
            else
            {
                return Unauthorized(response);
            }

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GetUserInfo(BaseUserRequest user)
        {
            var result = await _authApplication.GetUserInfo(user);
            if (result.Status == ResponseState.Success)
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized(result);
            }

        }

        [Authorize]
        [HttpPatch]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest user)
        {
            var result = await _authApplication.UpdateUser(user);
            if (result.Status == ResponseState.Success)
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized(result);
            }

        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(BaseUserRequest user)
        {
            var result = await _authApplication.DeleteUser(user);
            if (result.Status == ResponseState.Success)
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized(result);
            }

        }


    }
}
