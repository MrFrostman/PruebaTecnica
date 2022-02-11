using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;

namespace LoginWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthControler : ControllerBase
    {

        public static Member user = new Member();
        private readonly IConfiguration _configuration;

        public int MemberId { get; private set; }

        public AuthControler(IConfiguration configuration)
        {
            this._configuration = configuration;
        }


        [HttpPost("register")]
        public async Task<ActionResult<Member>> Register(MemberDto request)
        {
            CreatePasswordHash(request.Password,out byte[] passwordHash,out byte[] passwordSalt);
            user.MemberId = MemberId;
            user.Email=request.Email;
            user.PasswordHash= passwordHash;
            user.PassworSalt= passwordSalt; 
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(MemberDto request)
        {
            if(user.Email !=request.Email)
            {
                return BadRequest("User not Found");

            }
            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PassworSalt))
            {
                return BadRequest("Wrong Password");
            }

            string token = CreateToken(user);
            return Ok(token);
        }   

        private string CreateToken(Member user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,"Admin")
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token=new JwtSecurityToken(
                claims:claims,
                expires:DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }


        private bool VerifyPasswordHash(String password,byte [] passwordHash,byte [] passwordSalt)
        {
            using (var hmac = new HMACSHA512(user.PassworSalt))
            {
                var computehash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computehash.SequenceEqual(passwordHash);
            }
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash,out byte[]passwordSalt)
        {
            using(var hmac=new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
