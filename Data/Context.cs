using Microsoft.EntityFrameworkCore;
using Models;
using Shop.Models;

namespace Shop.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {}

        public DbSet<Customer> customers { get; set; }

        public DbSet<Orders> orders { get; set; }

        public DbSet<Products> products { get; set; }
        
        public DbSet<User> User {get; set;}
    }
}