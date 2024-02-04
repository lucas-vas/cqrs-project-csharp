using CQRS_Shop.Domain.Entities;
using CQRS_Shop.Infra.Data.Context;
using CQRS_Shop.Infra.Data.InterfacesRepositories;

namespace CQRS_Shop.Infra.Data.Repositories;

public class CustomerRepository : ICustomerRepository{

    private readonly ApplicationDbContext Db;

    public CustomerRepository(ApplicationDbContext db)
    {
        Db = db;
    }

    public async Task<List<Customer>> GetAll() {
        var result = Db.Customers.ToList();
        return result;
    }

    public async Task<Customer> GetById(int id) {
        var result = Db.Customers
                    .FirstOrDefault(x => x.Id == id);

        return result;
    }
}