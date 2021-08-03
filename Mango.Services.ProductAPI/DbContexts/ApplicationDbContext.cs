using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext:DbContext// we need an instanse of the dbcontext option class to work
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)// the instance carries the configuration information such as the connection string to use the database provider
        {

        }

        public DbSet<Product>Products { get; set; }// we use this property to query and save instances of the product class 

    }
}
