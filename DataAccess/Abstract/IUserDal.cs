using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);//Kullanıcının sisteme eklenmesi vs. yanında bir de claimlerini çekmek için bu metodu tanımladık
    }
}
