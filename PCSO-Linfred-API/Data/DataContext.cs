
using Microsoft.EntityFrameworkCore;
using PCSO_Linfred_API.Model;
namespace PCSO_Linfred_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Office> Offices { get; set; }
    }
}
