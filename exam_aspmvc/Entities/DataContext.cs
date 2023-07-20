using System;
using Microsoft.EntityFrameworkCore;
namespace exam_aspmvc.Entities
{
	public class DataContext :DbContext
	{
		public DataContext(DbContextOptions options) :base(options)
		{

			
		}
       

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("A FALLBACK CONNECTION STRING");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Contact> Contacts { get; set; }
	

    }
}

