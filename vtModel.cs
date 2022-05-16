using System;
using System.Data.Entity;
using System.Linq;

namespace sozlukApp
{
    public class vtModel : DbContext
    {
        public vtModel()
             : base("name=vtModel")
        {
        }

        public virtual DbSet<sozlukTablo> sozlukTabloVerileri { get; set; }
    }

    public class sozlukTablo
    {
        public int Id { get; set; }
        public string TrKelime { get; set; }
        public string IngKelime { get; set; }
    }
}