using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotnet_playground.Models;

namespace dotnet_playground.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        // Add DbSet<T> properties here
        // Created a table Categories in the database with columns from the Category Model Class
        public DbSet<Category> Categories { get; set; } 
    }
}