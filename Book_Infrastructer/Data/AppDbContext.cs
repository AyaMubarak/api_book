using Book_Core.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Infrastructer.Data
{
    public class AppDbContext : IdentityDbContext<Users, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IteamsUnites>().HasKey(i => new { i.Unit_Id, i.Iteam_Id });
            builder.Entity<InvoiceDetails>().HasKey(i => new { i.Invoice_Id, i.Iteam_Id });
            builder.Entity<CustomerStores>().HasKey(i => new { i.Cus_Id, i.Store_Id });
            builder.Entity<ShoppingCartIteams>().HasKey(i => new { i.Iteam_Id, i.Store_Id ,i.Cus_Id});
            builder.Entity<InvIteamStores>().HasKey(i => new { i.Store_Id, i.Iteam_Id });



        }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Classifications> Classifications { get; set; }
        public DbSet<CustomerStores> CustomerStores { get; set; }
        public DbSet<Governments> Governments { get; set; }
        public DbSet<InvIteamStores> InvIteamStores { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public DbSet<Iteams> Iteams { get; set; }
        public DbSet<IteamsUnites> IteamsUnites { get; set; }
        public DbSet<MainGroup> MainGroup { get; set; }
        public DbSet<SubGroup> SubGroup { get; set; }
        public DbSet<SubGroup2> SubGroup2 { get; set; }
        public DbSet<ShoppingCartIteams> ShoppingCartIteams { get; set; }
        public DbSet<Stores> Stores { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<Zones> Zones { get; set; }

    }
}
