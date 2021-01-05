using Store_Web.Data.Enteties;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_Web.Data
{
    public class Repository : IRepository
    {

        private readonly DataContext context;


        /* Serve para reconhecer a DB */
        public Repository(DataContext context)
        {
            this.context = context;
        }

        /* Serve para retornar todos os products da tabela */
        public IEnumerable<Product> GetProducts()
        {
            return this.context.Products.OrderBy(prop => prop.Name);
        }

        /* Serve para retornar um expecifico da tabela */
        public Product GetProduct(int id)
        {
            return this.context.Products.Find(id);
        }

        /* Serve para adicionar um product na tabela */
        public void AddProduct(Product product)
        {
            this.context.Products.Add(product);
        }

        /* Serve para editar/ fazer o Update do product na tabela */
        public void UpdateProduct(Product product)
        {
            this.context.Products.Update(product);
        }

        /* Serve para remover um product */
        public void RemoveProduct(Product product)
        {
            this.context.Products.Remove(product);
        }

        /* Serve para gravar na tabela */
        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        /* Serve para verificar se existe na tabela  */
        public bool ProductExists(int id)
        {
            return this.context.Products.Any(p => p.Id == id);
        }

    }
}
