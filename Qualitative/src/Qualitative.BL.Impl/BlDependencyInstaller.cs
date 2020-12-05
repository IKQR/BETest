using Microsoft.Extensions.DependencyInjection;
using Qualitative.BL.Abstract.IMapper;
using Qualitative.BL.Abstract.IService;
using Qualitative.BL.Impl.Mapper;
using Qualitative.BL.Impl.Service;
using Qualitative.DAL.Entities;
using Qualitative.Models.Student;

namespace Qualitative.BL.Impl
{
    public static class BlDependencyInstaller
    {
        public static void Install(this IServiceCollection services)
        {
            services.AddTransient<IGeneralMapper<Student, StudentModel>, StudentGeneralMapper>();

            services.AddTransient<IStudentService, StudentService>();
        }
    }
}
