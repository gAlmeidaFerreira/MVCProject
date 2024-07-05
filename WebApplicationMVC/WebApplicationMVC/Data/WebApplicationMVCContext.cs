using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Data
{
    public class WebApplicationMVCContext : DbContext
    {
        public WebApplicationMVCContext (DbContextOptions<WebApplicationMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<SalesRecord> SalesRecord { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; } = default!;

    }
}
