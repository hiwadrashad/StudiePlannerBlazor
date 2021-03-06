﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Server.Repositories
{
    public interface IRepository<TModel>
    {
        public TModel Add(TModel model);
        public TModel Delete(int id);
        public TModel Update(TModel model);
        public List<TModel> GetAll();
        public TModel GetById(int id);
    }
}
