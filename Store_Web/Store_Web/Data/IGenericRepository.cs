﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_Web.Data
{
    interface IGenericRepository<T> where T: class
    {
        IQueryable<T> GetAll();

        Task<T> GetByIdAsync(int id);


        Task CreateAsync(T entity);


        Task UpadteAsync(T entity);


        Task DeleteAsync(T entity);


        Task<bool> ExistsAsync(int id);
    }
}
