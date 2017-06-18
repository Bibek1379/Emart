using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Emart.Models
{
    public class TemplateContext : DbContext
    {
        public DbSet<Template> Template { get; set; }
        public DbSet<Vendor> Vendor { get; set; }

        public DbSet<Eshopper> Eshopper { get; set; }
    }
}