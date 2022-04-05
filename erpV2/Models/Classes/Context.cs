
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace erpV2.Models.Classes
{
    public class Context : DbContext
    {
     
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<SalesTransaction> SalesTransactions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Outgoing> Outgoings { get; set; }
    }
}