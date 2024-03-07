using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net;
using Diet_proyecto.Entities;
using Diet_proyecto.Models;
using Diet_proyecto.Services.Interfaces;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Diet_proyecto.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class AutenticateController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ICustomAuthenticationService _customAuthenticationService;

        public AutenticateController(IConfiguration config, ICustomAuthenticationService autenticacionService)
        {
            _config = config; 
            this._customAuthenticationService = autenticacionService;
        }

        [HttpPost("authenticate")] 
        public ActionResult<string> Autenticar(AuthenticationRequestBody authenticationRequestBody) 
        {
            //Paso 1: Validamos las credenciales
            var user = _customAuthenticationService.ValidateUser(authenticationRequestBody); 

            if (user is null) 
                return Unauthorized();

            //Paso 2: Crear el token
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"])); 

            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString())); //"sub" es una key estándar que significa unique user identifier, es decir, si mandamos el id del usuario por convención lo hacemos con la key "sub".
            claimsForToken.Add(new Claim("given_name", user.Name)); //given_name y family_name son las convenciones para nombre y apellido
            claimsForToken.Add(new Claim("family_name", user.LastName)); 
            claimsForToken.Add(new Claim("role", user.UserType));

            var jwtSecurityToken = new JwtSecurityToken( // Acá es donde se crea el token con toda la data que le pasamos antes.
              _config["Authentication:Issuer"],
              _config["Authentication:Audience"],
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(1),
              credentials);

            var tokenToReturn = new JwtSecurityTokenHandler() //Pasamos el token a string
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }
    }
}
