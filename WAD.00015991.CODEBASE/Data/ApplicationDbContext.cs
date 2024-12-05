using Microsoft.EntityFrameworkCore;
using WAD._00015991.CODEBASE.Models;

namespace WAD._00015991.CODEBASE.Data
// 00015991
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<FitnessActivity> FitnessActivities { get; set; } // Table for fitness activities
    }
}
// 00015991