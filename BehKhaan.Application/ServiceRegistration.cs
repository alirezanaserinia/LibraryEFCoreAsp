using BehKhaan.Application.Interfaces;
using BehKhaan.Application.Services;
using BehKhaan.Domain.IRepositories;
using BehKhaan.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BehKhaan.Application
{
    public static class ServiceRegistration
    {
        public static void AddInfraRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IShelfRepository, ShelfRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBook_ShelfRepository, Book_ShelfRepository>();
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}