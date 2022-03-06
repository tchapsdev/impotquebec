using impotquebec.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace impotquebec.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
        #endregion
        public DbSet<Declaration> Declarations { get; set; }
        public DbSet<DeclarationDetail> DeclarationDetails { get; set; }
        public DbSet<TaxFormSection> TaxFormSections { get; set; }
        public DbSet<IdentityProfile> IdentityProfiles { get; set; }
        public DbSet<TaxForm> TaxForms { get; set; }
        public DbSet<TaxFormLine> TaxFormLines { get; set; }
        public DbSet<FormDataType> FormDataTypes { get; set; }

    }
}