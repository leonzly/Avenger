using Microsoft.EntityFrameworkCore.Storage;

namespace Avenger.Repository
{
    public interface IDatabaseTransactionRepository
    {
        IDbContextTransaction BeginTransaction();
    }
}