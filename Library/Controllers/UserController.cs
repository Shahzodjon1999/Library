﻿using Damen.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        [HttpPost]
        public IActionResult Auth([FromBody] User user)
        {
            IActionResult response = Unauthorized();

            if (user != null)
            {
                if (user.UserName.Equals("test@email.com") && user.Password.Equals("1234"))
                {
                    var issuer = _configuration["Jwt:Issuer"];
                    var audience = _configuration["Jwt:Audience"];
                    var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                    var signingCredentials = new SigningCredentials(
                                            new SymmetricSecurityKey(key),
                                            SecurityAlgorithms.HmacSha512Signature
                                        );


                    var subject = new ClaimsIdentity(new[]
                    {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                });


                    var expires = DateTime.UtcNow.AddMinutes(10);


                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = subject,
                        Expires = DateTime.UtcNow.AddMinutes(10),
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = signingCredentials
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwtToken = tokenHandler.WriteToken(token);

                    return Ok(jwtToken);
                }
            }
            return response;
        }
    }
}
