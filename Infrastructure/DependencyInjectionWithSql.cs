using Application.Repositories;
using Application.Repositories.BookRepo;
using Application.RequestModels;
using Application.RequestModels.AuthorRequestModels;
using Application.RequestModels.BookRequestModels;
using Application.Services;
using Application.Services.AllServices;
using Application.Services.AllServicesInterfase;
using Application.Services.AuthorsService;
using Application.Services.BooksServices;
using FluentValidation;
using Infrastructure.Database;
using Infrastructure.RepositoriesInfrastucture;
using Infrastructure.RepositoriesInfrastucture.BookRepo;
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
            services.AddDbContext<ContractDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IContractDbContext>(option => option.GetService<ContractDbContext>());

            services.AddTransient<IAuthorService, AuthorService>();

            services.AddTransient<IAuthorRepository, AuthorRepository > ();


            services.AddTransient<IBookService, BookService>();

            services.AddTransient<IBookRepository, BookRepository>();


            services.AddTransient<ICategoryService, CategoryService>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();

            return services;
        }

        public static IServiceCollection AddAppValidation(this IServiceCollection services)
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
