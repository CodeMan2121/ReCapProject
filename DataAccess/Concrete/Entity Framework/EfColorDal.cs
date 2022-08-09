using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EfColorDal : EfEntityRepositoryBase<Color,NorthwindContext> ,IColorDal
    {//Buralara yani EfColorDal ve diğer Dal'lara veri tabanı elemanlarına uygulanacak olan temel metodları yazarız.
     //Tabi burası inherit edildiği için tüm metodları kapsayan bi soyutlama tekniği kullandık.

    }
}
