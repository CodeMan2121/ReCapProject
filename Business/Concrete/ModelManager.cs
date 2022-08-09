using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public IDataResult<List<Model>> GetAll()
        {
            
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll());
        }

        public IResult Add(Model model)
        {
            _modelDal.Add(model);
            return new SuccessResult();
        }

        public IResult Delete(Model model)
        {
            _modelDal.Delete(model);
            return new SuccessResult();
        }

        public IDataResult<List<Model>> GetModels(int modelId)
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll(m => m.ModelId == modelId));
        }

        public IResult Update(Model model)
        {
            _modelDal.Update(model);
            return new SuccessResult();
        }
    }
}
