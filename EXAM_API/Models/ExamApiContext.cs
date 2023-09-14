using System;
namespace EXAM_API.Models;

 using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

	public partial class ExamApiContext :DbContext
	{


    public static string ConnectionString;


    public ExamApiContext()
    {
    }
    public ExamApiContext(DbContextOptions<ExamApiContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<ProjectEmployee> ProjectEmployees { get; set; }

  
}

