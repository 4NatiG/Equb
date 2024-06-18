using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication10.Models;
using WebApplication10.Areas.Identity.Pages.Account;
namespace WebApplication10.Data
{
    public class AppDbcontext :DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {
        }
        public DbSet<Account> Account { get; set; }
        public DbSet<Transact> Transact { get; set; }
        public DbSet<equb_detail> equb_detail { get; set; }
        public DbSet<Equb_order> equb_order { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>().HasIndex(u => u.Id).IsUnique();
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

    }
}
