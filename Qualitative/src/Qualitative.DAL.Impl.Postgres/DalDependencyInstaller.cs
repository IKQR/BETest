using Microsoft.Extensions.DependencyInjection;
using Qualitative.DAL.Abstract.IRepository;
using Qualitative.DAL.Impl.Postgres.Repository;

namespace Qualitative.DAL.Impl.Postgres
{
    public static class DalDependencyInstaller
    {
        public static void Install(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
        }
    }
}
