using CQRS_Shop.Domain.Entities;

namespace CQRS_Shop.Infra.Data.InterfacesRepositories;

public interface ICustomerRepository{
    Task<List<Customer>> GetAll();
    Task<Customer> GetById(int id);
    Task Insert(Customer customer);
}