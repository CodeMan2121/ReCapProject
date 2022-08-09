using Core.Utilities;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IModelService
    {
        IDataResult<List<Model>> GetAll();

        IDataResult<List<Model>> GetModels(int modelId);

        IResult Add(Model model);
        IResult Update(Model model);
        IResult Delete(Model model);
    }
}
