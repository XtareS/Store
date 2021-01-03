﻿using Microsoft.EntityFrameworkCore;
using Store_Web.Data.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_Web.Data
{
    public class DataContext : DbContext
    {


        public DbSet<Product> Products {get; set;}


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


    }
}
