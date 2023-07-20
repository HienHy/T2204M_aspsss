using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using exam_aspmvc.Entities;
using exam_aspmvc.Models;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace exam_aspmvc.Controllers;

public class ContactController : Controller
{
    public readonly DataContext _context;
    public ContactController(DataContext dataContext)
    {
        _context = dataContext;
    }



    // GET: /<controller>/
    public IActionResult Index(string searchString)
    {




        var contacts = _context.Contacts
          
     
            .ToList();
     
        return View(contacts);




    }



    [HttpPost]
    public IActionResult Create(ContactViewModel viewModel)
    {

        if (ModelState.IsValid)
        {

            _context.Contacts.Add(new Contact { Name = viewModel.Name,Number=viewModel.Number,GroupName=viewModel.GroupName,HireDate=viewModel.HireDate,Birthday=viewModel.Birthday});



            _context.SaveChanges();

            return RedirectToAction("Index");

        }
        return View();
    }

    [HttpPost]
    public IActionResult Delete( )
    {

        
        return View();
    }







    // GET: /<controller>/

}



