using Damen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AuthorDbContext : DbContext, IAuthorDbContext
    {
        public AuthorDbContext(DbContextOptions<AuthorDbContext> options) : base(options)
        {
           // Database.EnsureCreated();
        }

        public DbSet<Author> Authors { get; set; }
    }
}
