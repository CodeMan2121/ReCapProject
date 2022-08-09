using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;

namespace Core.BusinessAspects.Autofac
{//Metodlar için yetki kontrolü yapar.Business'da iş katmanında her metoda if'li bir şekilde de yapabilirdik fakat kolaylık olsun diye aspect
    //hale getirip her metod için kullanılabilir bir duruma getirdik.
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;//Kullanıcı tarayıcıdan istekte bulunduğu zaman token gönderir.Aynı anda binlerce
        //kişi de istek de bulunabilir.Her bir istek için HttpContext oluşur.İşte bunları IHttpContextAccesor oluşturur.
        

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');//Split ile belirtilen nesnenin elemanlarını belirtien karakterlerle ayırıp array haline getiriyor.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();//Autofac'ta injection değerlerini alacak.

        }

        protected override void OnBefore(IInvocation invocation)
        {//Method çalışmadan önce kullanıcının claimlerini gez istenen rolde bir claim varsa metodu aynen çalıştır.Yoksa yetkiniz yok mesajı ver.
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;//metodu aynı çalıştır.
                }
            }
            throw new Exception("Yetkiniz yok!");
        }
    }
}
