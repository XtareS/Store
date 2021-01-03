﻿using Store_Web.Data.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_Web.Data
{
    public class SeedDb
    {
        private readonly DataContext context;

        /*gerador de 1ªs dados */
        private Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        /* Processo de criação de dados na primeira vez que a base de dados é utilizada  */
        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Products.Any())
            {
                this.AddProduct("Equipamento Oficial SLB");
                this.AddProduct("Chuteiras Oficiais SLB");
                this.AddProduct("Águia Pequena Oficial SLB");
                await this.context.SaveChangesAsync();
            }

        }

        /* dados que serão colocados automaticamente na primeira vez que a base de dados é utilizada  */
        private void AddProduct(string name)
        {
            this.context.Products.Add(new Product 
            {
            Name = name,
            Price = this.random.Next(200),
            IsAvailable =true,
            Stock = this.random.Next(100)
            
            });
        }
    }
}