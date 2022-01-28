using Core.Auth;
using Data.Uow;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class LoginResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorCode { get; set; }
        public string AccessToken { get; set; }
    }

    public class UserAuthentication
    {
        public static LoginResponse Auth(IUnitOfWork unitOfWork, LoginRequest request, IConfiguration configuration)
        {
            var user = unitOfWork.User.Where(x => x.UserName.Equals(request.UserName)).FirstOrDefault();
            if (user == null)
            {
                return new LoginResponse { IsSuccess = false, ErrorCode = "User€1" };
            }
            // todo password check

            // generate the token
            var key = configuration["JWT:Key"];
            var issuer = configuration["JWT:Issuer"];
            string token = TokenHandler.GenerateToken(key, issuer, user);

            if (string.IsNullOrEmpty(token))
            {
                return new LoginResponse { IsSuccess = false, ErrorCode = "User€2" };
            }
            else
            {
                return new LoginResponse { IsSuccess = true, AccessToken = token };
            }
        }
    }
}
