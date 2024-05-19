using CV_Manager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CV_Manager.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<ExperienceInformation> ExperienceInformations { get; set; }
        public DbSet<CV> CVs { get; set; }
    }
}
