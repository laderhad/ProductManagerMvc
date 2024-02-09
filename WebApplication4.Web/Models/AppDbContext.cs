using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Web.Models
{
	public class AppDbContext : DbContext


	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
		{ 
		
		}
        public DbSet<Product> Products { get; set; }

		public DbSet<Visitor> Visitors { get; set; }

    }
}
