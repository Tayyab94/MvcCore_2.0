using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booklist.Models
{
    public class DemoContext:DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> option)
            :base(option)
        {

        }

        //For the Connection goto the startUp.cs file then goto Configureservices

        public DbSet<BookClass> Books { get; set; }
    }
}
