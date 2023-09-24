using DemoCrudOperations.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoCrudOperations.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options):base(options)
        {

        }
        public DbSet<Customer> CustomerTB { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}
