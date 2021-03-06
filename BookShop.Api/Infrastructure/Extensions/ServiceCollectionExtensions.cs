﻿using System.Linq;
using System.Reflection;
using BookShop.Services;
using BookShop.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Api.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            Assembly
                .GetAssembly(typeof(IService))
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any(i => i.Name == $"I{t.Name}"))
                .Select(t => new
                {
                    Interface = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                })
                .ToList()
                .ForEach(s => services.AddTransient(s.Interface, s.Implementation));

            services.AddSingleton<IShoppingCartManager, ShoppingCartManager>();

            return services;
        }
    }
}