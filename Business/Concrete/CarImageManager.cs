using Business.Abstract;
using Business.Constant;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.FileHelperManager;
using DataAccess.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;

        }


        public IResult Add(IFormFile file ,CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimited(carImage.CarId));

            if (result != null)
            {
                return result;
            }            

            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }


        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath, PathConstants.ImagesPath + carImage.ImagePath);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult("Münasebetinde bulunduğunuz tamafilin resmi başarıyla güncellenmiştir!");
        }


        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }


        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }


        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        

        public IDataResult<List<CarImage>> GetByImageId(int imageId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.Id == imageId));
        }



        ////////////////////////Private Method//////////////////////////////////////////////////////////
        

        private IResult CheckIfCarImageLimited(int carId)
        {//Araba resmi 5'ten fazla olamaz.
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageLimited);
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImageData = new List<CarImage>();
            carImageData.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "wwwroot\\Upload\\Images\\Default.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImageData);
        }

        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId);
            if (result.Count > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
