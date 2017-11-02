using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Shalu2.Models
{
    public class BlogManager
    {

        public string Id { get; set; }
        public string Password { get; set; }
    }

    public class BlogManagerDBContext : DbContext
    {
        public DbSet<BlogManager> BlogManagers { get; set; }
    }
}