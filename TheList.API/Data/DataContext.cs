using Microsoft.EntityFrameworkCore;
using TheList.API.Models;

namespace TheList.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Category> Categories {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .HasIndex(u => u.Id)
                .IsUnique();
        }
        
    }
}