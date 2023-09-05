using Damen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class ContractDbContext : DbContext, IContractDbContext
    {
        public ContractDbContext(DbContextOptions<ContractDbContext>options):base(options)
        {
           
        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Book
            modelBuilder.Entity<Book>()
                .HasOne<Author>(g => g.Author)
                .WithMany(m => m.Books)
                .HasForeignKey(k => k.AuthorId);


            modelBuilder.Entity<Book>()
                .HasOne<Category>(c=>c.Category)
                .WithMany(m=>m.Books)
                .HasForeignKey(k=>k.CategoryId);

            

            //Author
             modelBuilder.Entity<Author>()
                .HasMany<Book>(b=>b.Books)
                .WithOne(o=>o.Author)
                .HasForeignKey(k=>k.AuthorId);


            //Category
            modelBuilder.Entity<Category>()
                .HasMany<Book>(b => b.Books)
                .WithOne(c => c.Category)
                .HasForeignKey(k => k.CategoryId);

          
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Worker> Workerss { get; set; }

        public DbSet<RentBook> RentBooks { get; set; }
    }
}
