using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {//Kullanıcı tarayıcıyla istekte bulunurken yetkilendirme gerekiyorsa elindeki token'ı da gönderir.
        public string Token { get; set; }//Gönderilen token'ın bilgisi. JWT değerimizin ta kendisi
        public DateTime Expiration { get; set; }//Token'ın geçerlilik süresi
    }
}
