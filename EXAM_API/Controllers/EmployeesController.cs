using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EXAM_API.DTOs;
using EXAM_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EXAM_API.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeesController : Controller
    {




        public readonly ExamApiContext _context;




        public EmployeesController(ExamApiContext context)
        {
            _context = context;
        }


        [HttpGet]

        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();



            return Ok(employees);
        }



        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                return Ok(new EmployeeDTO { EmployeeId = employee.EmployeeId, EmployeeName = employee.EmployeeName, EmployeeDepartment = employee.EmployeeDepartment, EmployeeDOB = employee.EmployeeDOB,ProjectEmployees=employee.ProjectEmployees });
            }
            return NotFound();
        }


        [HttpPost]
        public IActionResult Create(EmployeeDTO data)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee { EmployeeId = data.EmployeeId, EmployeeName = data.EmployeeName, EmployeeDepartment = data.EmployeeDepartment, EmployeeDOB = data.EmployeeDOB, ProjectEmployees = data.ProjectEmployees };
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return Created($"get-by-id?id={employee.EmployeeId}", new EmployeeDTO { EmployeeId = employee.EmployeeId, EmployeeName = employee.EmployeeName, EmployeeDepartment = employee.EmployeeDepartment, EmployeeDOB = employee.EmployeeDOB, ProjectEmployees = employee.ProjectEmployees });
            }
            return BadRequest();
        }




        [HttpPut]
        public IActionResult Update(Employee data)
        {
            if (ModelState.IsValid)
            {

                var employee = new Employee { EmployeeId = data.EmployeeId, EmployeeName = data.EmployeeName, EmployeeDepartment = data.EmployeeDepartment, EmployeeDOB = data.EmployeeDOB, ProjectEmployees = data.ProjectEmployees };

                _context.Employees.Update(employee);
                _context.SaveChanges();
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var employeeDelete = _context.Employees.Find(id);
            if (employeeDelete == null)
                return NotFound();
            _context.Employees.Remove(employeeDelete);
            _context.SaveChanges();
            return NoContent();
        }


    }





}

