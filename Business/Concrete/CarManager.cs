using FluentValidation;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Utilities;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constant;
using Core.CrossCuttingConserns.Validation;
using Core.Aspect.Autofac.Validation;
using Core.BusinessAspects.Autofac;
using Core.Aspect.Autofac.CacheAspect;
using Core.CrossCuttingConserns.Caching.Microsoft;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Performance;
//Manager Class'lar iş katmanının somut sınıfıdır.
namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheAspect]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)//Add metodunu doğrula yukardaki ValidationAspect ile CarValidator'u kullanarak(oradaki kurallara göre)
        {
            //Şuanda add methodunda validation kodları yok ama aspect ile yukarda ekledik.

            //ValidationTool.Validate(new CarValidator(), car);//Yukarıdaki attribute zaten bu kodları karşılıyor.
            //Buraya sadece business kodlarını yazacaz.

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]//IProductService'teki tüm Get'leri iptal et.
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

        ///////////////////////////////////////////// --GetAll-- ///////////////////////////////////////////////////////
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            //İş kodları.Yani burada tüm şartları geçerse GetCars() ile tüm Car verilerini döndür demek istiyor.
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }


        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarUpdated);
        }

    }
}
