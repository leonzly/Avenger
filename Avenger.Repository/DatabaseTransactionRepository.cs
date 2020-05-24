using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Avenger.Repository
{
    public class DatabaseTransactionRepository : IDatabaseTransactionRepository
    {
        private readonly DbContext _context;

        public DatabaseTransactionRepository(DbContext context)
        {
            _context = context;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}
