using CQRS_Shop.Domain.Entities;
using CQRS_Shop.Infra.Data.Context;
using CQRS_Shop.Infra.Data.InterfacesRepositories;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Shop.Infra.Data.Repositories;

public class CustomerRepository(ApplicationDbContext db) : ICustomerRepository
{
    public async Task<List<Customer>> GetAll() {
        var result = await db.Customers.ToListAsync();
        return result;
    }

    public async Task<Customer> GetById(int id) {
        var result = await db.Customers.FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }

    public async Task Insert(Customer customer){
        await db.Customers.AddAsync(customer);
    }
}