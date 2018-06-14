﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IRepository<T> where T: BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T Entity);
        void Update(T Entity);
        void Remove(T Entity);
        void Delete(T Entity);
        void SaveChanges();
    }
}
