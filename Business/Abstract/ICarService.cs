using Core.Utilities;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();

        IDataResult<Car> GetById(int carId);

        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);

        IResult TransactionalOperation(Car car);
    }
}
