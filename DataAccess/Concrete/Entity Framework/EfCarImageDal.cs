using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage,NorthwindContext> , ICarImageDal
    {
    }
}
