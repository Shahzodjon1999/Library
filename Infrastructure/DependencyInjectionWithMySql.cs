using Application.Repositories.BookRepo;
using Application.Repositories;
using Application.RequestModels.AuthorRequestModels;
using Application.RequestModels.BookRequestModels;
using Application.RequestModels;
using Application.Services.AllServices;
using Application.Services.AllServicesInterfase;
using Application.Services.AuthorsService;
using Application.Services.BooksServices;
using Application.Services;
using Infrastructure.Database;
using Infrastructure.RepositoriesInfrastucture.BookRepo;
using Infrastructure.RepositoriesInfrastucture;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public static class DependencyInjectionWithMySql
    {
        public static IServiceCollection AddApplicationMySqlCon(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContractDbContext>(op => op.UseMySql(configuration.GetConnectionString("DefaultMySqlConnection"), new MySqlServerVersion(new Version(8, 0, 11))));

            services.AddScoped<IContractDbContext>(option => option.GetService<ContractDbContext>());

            services.AddTransient<IAuthorService, AuthorService>();

            services.AddTransient<IAuthorRepository, AuthorRepository>();


            services.AddTransient<IBookService, BookService>();

            services.AddTransient<IBookRepository, BookRepository>();


            services.AddTransient<ICategoryService, CategoryService>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();

            return services;
        }

        public static IServiceCollection AddAppValidationMySql(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(CreateAuthorRequestModel).Assembly);

            services.AddValidatorsFromAssembly(typeof(UpdateAuthorRequestModel).Assembly);


            services.AddValidatorsFromAssembly(typeof(CreateBookRequestModel).Assembly);

            services.AddValidatorsFromAssembly(typeof(UpdateBookRequestModel).Assembly);


            services.AddValidatorsFromAssembly(typeof(CreateCategoryRequestModel).Assembly);

            services.AddValidatorsFromAssembly(typeof(UpdateCategoryRequestModel).Assembly);

            return services;
        }
    }
}
