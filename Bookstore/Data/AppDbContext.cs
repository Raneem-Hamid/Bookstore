using Bookstore.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Security.AccessControl;
using System.Text.RegularExpressions;

namespace Bookstore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

		public DbSet<Book> Books { get; set; }



		protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            

        }
    }
}
