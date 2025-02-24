using InvelopContactManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InvelopContactManager.Infrastructure
{
    public class InvelopDbContext(DbContextOptions<InvelopDbContext> options) : DbContext(options)
    {
        public DbSet<Contact> Contacts { get; set; }
    }
}