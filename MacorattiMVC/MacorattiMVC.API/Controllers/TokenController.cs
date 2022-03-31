using MacorattiMVC.API.Models;
using MacorattiMVC.Domain.Contas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MacorattiMVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authentication;
        private readonly IConfiguration _configuration;

        public TokenController(IAuthenticate authentication, IConfiguration configuration)
        {
            _authentication = authentication ??
                throw new ArgumentNullException(nameof(authentication));
            _configuration = configuration;
        }

        [HttpPost("CreateUser")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult> CreateUser([FromBody] LoginModel userInfo)
        {
            var result = await _authentication.RegisterUser(userInfo.Email, userInfo.Password);

            if (result)
            {
                
                return Ok($"User {userInfo.Email} was created successfully");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                return BadRequest(ModelState);
            }
        }

        [HttpPost("LoginUsser")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel model)
        {
            var result = await _authentication.Authenticate(model.Email, model.Password);
            if (result)
            {
                return GenerateToken(model);
               // return Ok($"User{model.Email}Login sucesso");
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Invalid Login attempt.");
                return BadRequest(ModelState);
            
            }
        
        }

        private UserToken GenerateToken(LoginModel model)
        {
            //declação do usuario
            var claims = new[]
            {
                new Claim("email", model.Email),
                new Claim("meuValor", "oq vc quer"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            //gerar chave privada para assinar o tokin

            var privatekey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["jwt:SecretKey"]));

            //gerar a assinatura digital
            var credential = new SigningCredentials(privatekey, SecurityAlgorithms.HmacSha256);
            //defini o tempo de expiração
            var expiration = DateTime.UtcNow.AddMinutes(50);
            //gerar o token
            JwtSecurityToken token = new JwtSecurityToken(
                //emissor
                issuer:_configuration["jwt:Issuer"],
                //audiencia
                audience:_configuration["jwt:Audience"],
                //Claims
                claims: claims,
                //Data de expiração
                expires: expiration,
                //assinatura digital
                signingCredentials: credential
                
                );
            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler()
                .WriteToken(token),
                Expiration = expiration
            };

        }


    }
}
