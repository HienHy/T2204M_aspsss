using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T2204M_ASPNETMVC.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using T2204M_ASPNETMVC.Models;
using static System.Reflection.Metadata.BlobBuilder;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace T2204M_ASPNETMVC.Controllers
{
    public class ProductController : Controller
    {


        public readonly DataContext _context;
        public ProductController(DataContext dataContext)
        {
            _context = dataContext;
        }



        // GET: /<controller>/
        public IActionResult Index(string searchString)
        {




            var products = _context.Products
                .Include(c => c.Category)
                .Include(c => c.Brand)

                //.Where(c =>
                //{
                //    if (!String.IsNullOrEmpty(searchString))
                //    {
                //        searchString = searchString.ToLower();
                //        return c.Name.ToLower().Contains(searchString);
                //    }
                  
                //}


                // )
                .ToList();
            //Where(c => c.Name.Contains("one").
            //OrderBy(c=>c.Name)
            //OrderByDescending(c=>c.Name)

            //.Take(1)

            //.Skip(1)


            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    searchString = searchString.ToLower();

            //    products = products.Where(c => c.Name.ToLower().Contains(searchString));
          
            // }
            return View(products);


            //ViewData["categories"] = categories; //su dung cho du lieu nho


            //ViewBag.Products = products;



        }


        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel viewModel)
        {

            if (ModelState.IsValid)
            {

                _context.Products.Add(new Product { Name = viewModel.Name });



                _context.SaveChanges();

                return RedirectToAction("Index");

            }
            return View();
        }








        // GET: /<controller>/

    }
}

