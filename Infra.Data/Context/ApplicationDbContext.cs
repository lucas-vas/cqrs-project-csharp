using CQRS_Shop.Domain.Entities;
using CQRS_Shop.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Shop.Infra.Data.Context;

public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerMapping());
    }
}