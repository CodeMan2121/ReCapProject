﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entites.Concrete
{
    public class Model : IEntity
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
    }
}
