using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FlatTest.Models
{
    public class FlatTestContext: DbContext 
    {
        public FlatTestContext()
            : base("FlatTestContext")
        {
            
        }
            
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Story> Stories { get; set; }
            
    }
}