using AspNetCoreWithReact.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWithReact
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {

        }
        public AppDataContext()
        {

        }
        public DbSet<Libra> Libras { get; set; }
    }
}
