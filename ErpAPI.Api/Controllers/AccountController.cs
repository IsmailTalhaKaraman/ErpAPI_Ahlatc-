using ErpAPI.Api.Aspects;
using ErpAPI.Api.Validation.FluentValidation;
using ErpAPI.Busines.Abstract;
using ErpAPI.EEntity.DTO.LoginDTO;
using ErpAPI.EEntity.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace ErpAPI.Api.Controllers
{
    [ApiController]
    [Route("[action")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public AccountController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("/Login")]
        [ValidationFilter(typeof(LoginValidator))]
        [ProducesResponseType(typeof(Sonuc<LoginResponseDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            var user = await _userService.GetAsync(q => q.UserName == loginRequestDTO.KullaniciAdi &&
            q.Pasword == loginRequestDTO.Sifre);

            if (user==null)
            {
                return NotFound(Sonuc<LoginResponseDTO>.SuccesNoDataFound());
            }
            else
            {
                var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:JWTKey"));
                var claims = new List<Claim>();
                claims.Add(new Claim("kullaniciAdi", user.UserName));
                claims.Add(new Claim("kullaniciID", user.ID.ToString()));
                claims.Add(new Claim("AdSoyad", user.FirstName + user.LastName));


                var jwt = new JwtSecurityToken(
                    
                    expires:DateTime.Now.AddDays(90),
                    notBefore:DateTime.Now,
                    claims:claims,
                    issuer:"http://erpApi.com",
                    signingCredentials:new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
                    );

                var token = new JwtSecurityTokenHandler().WriteToken(jwt);
                LoginResponseDTO loginResponseDTO = new()
                {
                    AdSoyad = user.FirstName + " " + user.LastName,
                    EPosta = user.Email,
                    Token = token
                };
                return Ok(Sonuc<LoginResponseDTO>.SuccesWithData(loginResponseDTO));
            }
        }
    }
}
