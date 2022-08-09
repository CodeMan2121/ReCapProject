using Core.Entities.Concrete;
using Core.Utilities;
using Core.Utilities.Security.JWT;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{//Kayıt olmak veya giriş yapmak için gerekli operasyonları içeriyor.
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
