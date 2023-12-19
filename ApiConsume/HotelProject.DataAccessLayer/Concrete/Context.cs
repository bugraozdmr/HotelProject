using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.DataAccessLayer.Concrete
{
	// int verme sebebi idler intler otomatik artıyor -- string olsada olurdu
	public class Context : IdentityDbContext<AppUser,AppRole,int>
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
		public DbSet<About> Abouts { get; set; }
	}
}
