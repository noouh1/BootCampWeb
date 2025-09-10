using System.Reflection;
using FluentValidation;
using MediatR;
using WebApplication1.Behaviour;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Repositories.Implementations;


namespace WebApplication1.Repositories;

public static class RepositoryDependencies
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped<IStudentRepository,StudentRepository>();
        services.AddScoped<ICourseRepository,CourseRepository>();
        return services;
    }
}