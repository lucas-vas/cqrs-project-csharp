namespace CQRS_Shop.Infra.Data.Integration.Interfaces;

public interface IUnitOfWork {
    void Commit();
    void CommitAsync();
}