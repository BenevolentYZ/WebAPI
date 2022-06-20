using Microsoft.EntityFrameworkCore;
using TaskManagementDomain;
using TaskManagementDomain.Models;

namespace TaskManagementRepository
{
    public class WebAPIDbContext:DbContext
    {
        public WebAPIDbContext(DbContextOptions<WebAPIDbContext> options) : base(options)
        { 
        }

        public DbSet<Quote> Quotes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
