﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store_Web.Data;
using Store_Web.Data.Enteties;
using Store_Web.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace Store_Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository productrepository;
        private readonly IUserHelper userHelper;

        public ProductsController(IProductRepository productrepository, IUserHelper userHelper)
        {

            this.productrepository = productrepository;
            this.userHelper = userHelper;
        }

        // GET: Products
        public IActionResult Index()
        {
            return View(this.productrepository.GetAll()/*.OrderBy(p => p.Name)*/);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await this.productrepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,ImageUrl,LastPurchase,LastSale,IsAvailable,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {

                //TODO:Change for The Logged User

                product.User = await this.userHelper.GetUserByEmailAsync(" Xtare16.Soares@gmail.com");

                await this.productrepository.CreateAsync(product);

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await this.productrepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,ImageUrl,LastPurchase,LastSale,IsAvailable,Stock")] Product product)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    //TODO:Change for The Logged User

                    product.User = await this.userHelper.GetUserByEmailAsync(" Xtare16.Soares@gmail.com");
                    await this.productrepository.UpdateAsync(product);
               
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.productrepository.ExistsAsync(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await this.productrepository.GetByIdAsync(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await this.productrepository.GetByIdAsync(id);
            await this.productrepository.DeleteAsync(product);
           
            return RedirectToAction(nameof(Index));
        }
    }
}
