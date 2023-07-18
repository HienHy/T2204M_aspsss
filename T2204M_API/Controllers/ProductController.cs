using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T2204M_API.DTOs;
using T2204M_API.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace T2204M_API.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        // GET: /<controller>/
        public readonly T2204mApiContext _context;




        public ProductController(T2204mApiContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult Index()
        {
            var products = _context.Products.ToList();



            //foreach (var item in products)
            //{
            //    List<ProductDTO> plist = new List<ProductDTO>();
            //    foreach (var p in item.Products)
            //    {
            //        plist.Add(new ProductDTO { id = p.Id, name = p.Name });

            //    }



            //    list.Add(new CategoryDTO { id = item.Id, name = item.Name, products = plist });
            //}

            return Ok(products);
        }



        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                return Ok(new ProductDTO { id = product.Id, name = product.Name,price =product.Price, description = product.Description});
            }
            return NotFound();
        }



        [HttpPost]
        public IActionResult Create(ProductDTO data)
        {
            if (ModelState.IsValid)
            {
                var product = new Product { Name = data.name,Price=data.price,Description=data.description };
                _context.Products.Add(product);
                _context.SaveChanges();
                return Created($"get-by-id?id={product.Id}", new ProductDTO { id = product.Id, name = product.Name,price=product.Price,description=product.Description });
            }
            return BadRequest();
        }




    }


   
}

