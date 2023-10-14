using ABP_test.Model;
using ABP_test.Models;
using Microsoft.EntityFrameworkCore;

namespace ABP_test.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<ExperimentResult> ExperimentsResult { get; set; }
    }
}
