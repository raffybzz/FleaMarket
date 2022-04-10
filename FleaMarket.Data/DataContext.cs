using FleaMarket.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FleaMarket.Data;

public class DataContext : IdentityDbContext<IdentityUser>
{
    public DbSet<DbProduct> Products { get; set; }
    public DbSet<DbTrade> Trades { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        base.Database.EnsureCreated();
    }
}
