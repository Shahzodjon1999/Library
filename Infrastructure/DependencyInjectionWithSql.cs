using Application.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjectionWithSql
    {
        public static IServiceCollection AddApplication(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AuthorDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IAuthorDbContext>(option => option.GetService<AuthorDbContext>());

            services.AddScoped<IAuthorService, AuthorService>();

            services.AddScoped<IAuthorRepository, AuthorRepository > ();

            return services;
        }
    }
}
