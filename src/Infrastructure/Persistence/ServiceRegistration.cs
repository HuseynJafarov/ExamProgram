using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Persistence.Services;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection ServiceDescriptors(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
