//using Avenger.Repository.ShieldDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Avenger.Repository
{
    public class DependencyInjectionConfiguration
    {
        public static void Register(IServiceCollection services)
        {
            // General repository.
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped<IStoredProcedureRepository, StoredProcedureRepository>();
            services.AddScoped<IDatabaseTransactionRepository, DatabaseTransactionRepository>();
            //services.AddScoped<DbContext, ShieldDBContext>();
        }
    }
}
