using RepositoryMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RepositoryMvc.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
                
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}