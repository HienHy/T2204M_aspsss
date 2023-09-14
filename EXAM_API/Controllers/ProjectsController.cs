using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EXAM_API.DTOs;
using EXAM_API.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EXAM_API.Controllers
{
    [ApiController]
    [Route("api/project")]
    public class ProjectsController : Controller
    {

        public readonly ExamApiContext  _context;




        public ProjectsController(ExamApiContext context)
        {
            _context = context;
        }


        [HttpGet]

        public IActionResult Index()
        {
            var projects = _context.Projects.ToList();



            return Ok(projects);
        }
        [HttpGet, Route("get-detail")]
        async public Task<IActionResult> GetDetail(int? id)
        {
            if (id == null)
            {
                var projects = _context.Projects.Include(e => e.ProjectEmployees).ThenInclude(e => e.Employees).ToListAsync();
                return Ok(projects);
            }
            var project = await _context.Projects.Include(e => e.ProjectEmployees).ThenInclude(e => e.Employees).Where(e => e.ProjectId.Equals(id)).ToListAsync();
            if (project == null) return NotFound();
            return Ok(project);
        }


        [HttpGet, Route("search-by-name")]
        async public Task<IActionResult> SearchByName(string? name)
        {
            var p = await _context.Projects.Where(e => e.ProjectName.Equals(name)).ToListAsync();
            return Ok(p);
        }

        [HttpGet, Route("search-by-startdate")]
        async public Task<IActionResult> SearchByStartDate(DateTime startdate)
        {
            if (startdate != null)
            {
                var ps = await _context.Projects.Where(e => e.ProjectStartDate.CompareTo(startdate) == 0).ToListAsync();
                return Ok(ps);
            }

            var p = await _context.Projects.Where(e => e.ProjectStartDate.CompareTo(DateTime.Now) > 0).ToListAsync();
            return Ok(p);
        }

        [HttpGet, Route("search-by-enddate")]
        async public Task<IActionResult> SearchByEndDate(DateTime enddate)
        {
            if (enddate != null)
            {
                var ps = await _context.Projects.Where(e => e.ProjectEndDate.CompareTo(enddate) == 0).ToListAsync();
                return Ok(ps);
            }

            var p = await _context.Projects.Where(e => e.ProjectEndDate.CompareTo(DateTime.Now) < 0).ToListAsync();
            return Ok(p);
        }




        [HttpGet]
        [Route("get-by-id")]
        public IActionResult Get(int id)
        {
            var project = _context.Projects.Find(id);
            if (project != null)
            {
                return Ok(new ProjectDTO { ProjectId = project.ProjectId, ProjectName = project.ProjectName, ProjectEndDate = project.ProjectEndDate, ProjectStartDate = project.ProjectStartDate });
            }
            return NotFound();
        }


        [HttpPost]
        public IActionResult Create(ProjectDTO data)
        {
            if (ModelState.IsValid)
            {
                var project = new Project { ProjectId = data.ProjectId, ProjectName = data.ProjectName, ProjectStartDate = data.ProjectStartDate, ProjectEndDate = data.ProjectEndDate,ProjectEmployees=data.ProjectEmployees };
                _context.Projects.Add(project);
                _context.SaveChanges();
                return Created($"get-by-id?id={project.ProjectId}", new ProjectDTO { ProjectId = project.ProjectId, ProjectName = project.ProjectName, ProjectEmployees = project.ProjectEmployees, ProjectEndDate = project.ProjectEndDate,ProjectStartDate=project.ProjectStartDate });
            }
            return BadRequest();
        }




        [HttpPut]
        public IActionResult Update(Project data)
        {
            if (ModelState.IsValid)
            {

                var project = new Project { ProjectId = data.ProjectId, ProjectName = data.ProjectName, ProjectStartDate = data.ProjectStartDate, ProjectEndDate = data.ProjectEndDate, ProjectEmployees = data.ProjectEmployees };

                _context.Projects.Update(project);
                _context.SaveChanges();
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var projectDelete = _context.Projects.Find(id);
            if (projectDelete == null)
                return NotFound();
            _context.Projects.Remove(projectDelete);
            _context.SaveChanges();
            return NoContent();
        }



    }
}

