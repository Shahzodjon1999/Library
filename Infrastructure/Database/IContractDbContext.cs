using Damen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public interface IContractDbContext
    {
        DbSet<Author> Authors { get; set; }

        DbSet<Book> Books { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<Customer> Customers { get; set; }

        DbSet<Worker> Workerss { get; set; }

        DbSet<RentBook> RentBooks { get; set; }
    }
}
