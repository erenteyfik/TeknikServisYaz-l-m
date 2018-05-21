using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TeknikServisYazılım.Entity;
using TeknikServisYazılım.Identity;
using TeknikServisYazılım.Models;

namespace TeknikServisYazılım
{
    public class DataContext: IdentityDbContext<ApplicationUser>
    {
        public DataContext():base ("dataConnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>("DataContext"));
        }

        public DbSet<Company> Companys { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ServiceRegistrationForm> SRFs { get; set; }
        public DbSet<TechnicalServiceLog> TSLogs { get; set; }
        public DbSet<Sellproduct> Sellproducts { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<SupplierPaymentList> SupplierPaymentLists { get; set; }
        public DbSet<Bank> Banks { get; set; }

    }
}