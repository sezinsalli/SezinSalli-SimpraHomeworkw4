﻿using SimApi.Base.Model;
using SimApi.Data.Context;
using SimApi.Data.Domain;
using SimApi.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Data.UnitOfWork
{
    public interface IUnitofWork : IDisposable
    {
        IGenericRepository<Category> CategoryRepository { get; }      
        IGenericRepository<Entity> Repository<Entity>() where Entity : BaseModel;

        void Complete();
        void CompleteWithTransaction();


    }
}