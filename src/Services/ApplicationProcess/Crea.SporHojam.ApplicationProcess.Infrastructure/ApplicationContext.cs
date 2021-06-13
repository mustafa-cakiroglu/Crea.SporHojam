using Crea.SporHojam.ApplicationProcess.Domain.Models;
using Crea.SporHojam.Data.Common;
using Crea.SporHojam.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Crea.SporHojam.ApplicationProcess.Infrastructure
{
    public class ApplicationContext : CreaDbContext, IUnitOfWork
    {
        public static readonly string DefaultSchema = "App";

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Role> Role { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(DefaultSchema);
        }
    }
}
