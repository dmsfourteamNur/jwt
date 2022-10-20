

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
/*https://dvoituron.com/2017/12/19/how-to-create-a-webapi-authenticated-by-jwt/*/
/*https://www.youtube.com/watch?v=3l4KHG2mppc*/
namespace MyJsonWebToken.Controllers
{
    public class TokenController : Controller
    {
        private const string SECRET_KEY = "alvaro_siles_estrada_llave_secret";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new
               SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));

        private bool IsAdmin;

        [HttpGet]
        [Route("api/token/{username}/{password}")]

        public IActionResult Get(string username, string password)
        {



            if (username == "admin" && password == "1234")
            {
                IsAdmin = true;
                return new ObjectResult(GenerateToken(username, "admin"));
            }
            else
              if (username == "alvaro" && password == "alvaro")
            {
                IsAdmin = true;
                return new ObjectResult(GenerateToken(username, "admin"));

            }
            else if (username == "user" && password == "user")
            {
                IsAdmin = false;
                return new ObjectResult(GenerateToken(username, "user"));
            }
            else if (username == "liceth" && password == "liceth")
            {
                IsAdmin = false;
                return new ObjectResult(GenerateToken(username, "rrhh"));
            }
            else if (username == "ricky" && password == "ricky")
            {
                IsAdmin = false;
                return new ObjectResult(GenerateToken(username, "admin"));
            }
            else if (username == "edson" && password == "edson")
            {
                IsAdmin = false;
                return new ObjectResult(GenerateToken(username, "operador"));
            }
            else if (username == "venta" && password == "venta")
            {
                IsAdmin = false;
                return new ObjectResult(GenerateToken(username, "vendedor"));
            }
            else if (username == "aeronave" && password == "aeronave")
            {
                IsAdmin = false;
                return new ObjectResult(GenerateToken(username, "admin"));
            }
            else
            {
                return BadRequest();
            }
        }

        private string GenerateToken(string username, string tipo)
        {
            var token = new JwtSecurityToken(
                   claims: new Claim[] {
                       new Claim("userType", tipo),
                       new Claim("user", username)
                   },
            //notBefore: new DateTimeOffset(DateTime.Now).DateTime,
            expires: new DateTimeOffset(DateTime.Now.AddMinutes(60)).DateTime,
            signingCredentials: new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
