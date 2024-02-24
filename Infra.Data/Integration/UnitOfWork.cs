using CQRS_Shop.Infra.Data.Context;
using CQRS_Shop.Infra.Data.Integration.Interfaces;

namespace CQRS_Shop.Infra.Data.Integration;

public class UnitOfWork(ApplicationDbContext db) : IUnitOfWork
{
    public void Commit(){
        db.SaveChanges();
    }

    public async Task CommitAsync(CancellationToken cancellationToken){
        await db.SaveChangesAsync(cancellationToken);
    }
}