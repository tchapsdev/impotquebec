using Tchaps.Impotquebec.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Tchaps.Impotquebec.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppUserRole, Guid>
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            : base(options)
        {
        }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configure();
            modelBuilder.Seed();
        }
        #endregion
        public DbSet<Declaration> Declarations { get; set; }
        public DbSet<DeclarationDetail> DeclarationDetails { get; set; }
        public DbSet<TaxFormSection> TaxFormSections { get; set; }
        public DbSet<TaxForm> TaxForms { get; set; }
        public DbSet<TaxFormLine> TaxFormLines { get; set; }
        public DbSet<FormDataType> FormDataTypes { get; set; }

    }
}