using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DependencyInjection.Config.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Runner
{
    public static class DiServicesProviderExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] {@"bin\"}, StringSplitOptions.None)[0];

            var Ass = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x =>
                {
                    string name = x.GetName().Name;
                    return name.Contains("WeeksPlanning");
                }).ToList();

            Ass.Add(Assembly.Load("WeeksPlanning.Core"));
            Ass.Add(Assembly.Load("WeeksPlanning.Repositories"));
            Ass.Add(Assembly.Load("WeeksPlanning.Services"));
            
            var assemblies = Ass;

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
                    if (inter != null){
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