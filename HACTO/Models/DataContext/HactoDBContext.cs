using HACTO.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HACTO.Models.DataContext
{
    public class HactoDBContext:DbContext
    {
        public HactoDBContext():base("HactoDB")
        {

        }
        //Tabloları teker teker veritabınına set etmemiz gerekiyor
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Hakkimizda> Hakkimizda { get; set; }
        public DbSet<Hizmet> Hizmet { get; set; }
        public DbSet<İletisim> İletisim { get; set; }
        public DbSet<Kimlik> Kimlik { get; set; }
        public DbSet<Slider> Slider { get; set; }
      
    }
}