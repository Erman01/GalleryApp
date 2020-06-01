using GalleryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.DataAccess.SQL
{
    public class DataContext:DbContext
    {
        public DataContext():base("GalleryAppConStr")
        {

        }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
