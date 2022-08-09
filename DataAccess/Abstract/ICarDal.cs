using Core.DataAccess;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();

        //List<Car> GetCars();

        //void Add(Car car);

        //void Update(Car car);

        //void Delete(Car car);
    }
}
