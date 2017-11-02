using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebShauli.Models
{
    public class Fan
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public DateTime birthDay { get; set; }
        public int seniority { get; set; }

        //menu View -> Other windows -> Package Manager Console
        //install-package entityframework -version 5.0.0.0
    }

    public class FanDBContext : DbContext
    {
        public DbSet<Fan> Fans { get; set; }
    }

}