using Microsoft.EntityFrameworkCore;
using SimApi.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Data.Context
{
    public class SimDbContext : DbContext
    {
        public SimDbContext(DbContextOptions<SimDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category{ get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<UserLog> UserLog { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<TransactionView> TransactionView { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserLogConfiguration());

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionViewConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
