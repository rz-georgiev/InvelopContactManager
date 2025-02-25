using InvelopContactManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace InvelopContactManager.Infrastructure
{
    public class InvelopDbContext : DbContext
    {
        public InvelopDbContext(DbContextOptions<InvelopDbContext> options)
         : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}