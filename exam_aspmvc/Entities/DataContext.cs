using System;
using Microsoft.EntityFrameworkCore;
namespace exam_aspmvc.Entities
{
	public class DataContext :DbContext
	{
		public DataContext(DbContextOptions options) :base(options)
		{

			
		}

		public DbSet<Contact> Contacts { get; set; }
	

    }
}

