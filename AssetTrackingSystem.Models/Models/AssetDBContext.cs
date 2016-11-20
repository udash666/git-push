using System.Data.Entity;
using System.Data.Entity.Validation;
using AssetTrackingSystem.Models.Models;
using Asset_Tracking_System.Models;

namespace AssetTrackingSystem.Models.Models
{
    public class AssetDBContext : DbContext
    {
        public DbSet<Organization> organizations { get; set; }
        public DbSet<AssetLocation> assetLocations { get; set; }
        public DbSet<Branch> branches { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<GeneralCategory> generalCategories { get; set; }
        public DbSet<SubCategory> subCategories { get; set; }
        public DbSet<DetailsCategory> detailsCategories { get; set; }
        public DbSet<AssetEntry> assetEntries { get; set; }
        public DbSet<AssetRegistration> assetRegistrations { get; set; }
    }   
}