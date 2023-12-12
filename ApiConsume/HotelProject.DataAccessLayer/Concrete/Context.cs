using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.DataAccessLayer.Concrete
{
	public class Context : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// trusted certificated olmazsa çalışmaz
			optionsBuilder.UseSqlServer(@"server=WINDOWSXP\MSSQLSERVER01;
			initial catalog=ApiDb;integrated security=true;TrustServerCertificate=True");
		}
		// sol sınıf ismi sag tablo ismi
		public DbSet<Room> Rooms { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<Staff> Staffs { get; set; }
		public DbSet<Subscribe> Subscribes { get; set; }
		public DbSet<Testimonial> Testimonials { get; set; }
	}
}
