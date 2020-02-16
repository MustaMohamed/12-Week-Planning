using System;
using System.Linq;
using System.Reflection;
using Framework.DependencyInjection.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.DependencyInjection
{
    public static class DiServicesProviderExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x =>
                {
                    string name = x.GetName().Name;
                    return name.Contains("WeeksPlanning");
                }).ToList();

            assemblies.Add(Assembly.Load("WeeksPlanning.Core"));
            assemblies.Add(Assembly.Load("WeeksPlanning.Repositories"));
            assemblies.Add(Assembly.Load("WeeksPlanning.Services"));

            // Scoped
            var enumerable = assemblies.ToList();

            enumerable.SelectMany(x => x.GetTypes())
                .Where(p => p.IsClass && p.IsDefined(typeof(CreateInScopeAttribute), inherit: false))
                .ToList()
                .ForEach(p =>
                {
                    var inter = p.GetInterfaces().FirstOrDefault(i => i.Name.Equals($"I{p.Name}"));
                    if (inter != null)
                    {
                        services.AddScoped(inter, p);
                    }
                    else
                    {
                        services.AddScoped(p);
                    }
                });

            // Singleton
            enumerable.SelectMany(x => x.GetTypes())
                .Where(p => p.IsClass && p.IsDefined(typeof(CreateSingletonAttribute), inherit: false))
                .ToList()
                .ForEach(s =>
                {
                    var inter = s.GetInterfaces().FirstOrDefault(i => i.Name.Equals($"I{s.Name}"));
                    if (inter != null)
                    {
                        services.AddSingleton(inter, s);
                    }
                    else
                    {
                        services.AddSingleton(s);
                    }
                });

            // Transient
            enumerable.SelectMany(x => x.GetTypes())
                .Where(p => p.IsClass && p.IsDefined(typeof(CreateTransientAttribute), inherit: false))
                .ToList()
                .ForEach(s =>
                {
                    var inter = s.GetInterfaces().FirstOrDefault(i => i.Name.Equals($"I{s.Name}"));
                    if (inter != null)
                    {
                        services.AddTransient(inter, s);
                    }
                    else
                    {
                        services.AddTransient(s);
                    }
                });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
    }
}