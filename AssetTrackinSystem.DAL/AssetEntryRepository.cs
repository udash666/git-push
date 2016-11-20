using Asset_Tracking_System.Models;
using AssetTrackingSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackinSystem.DAL
{
    public class AssetEntryRepository
    {
        private AssetDBContext db;
        public AssetEntryRepository()
        {
           db = new AssetDBContext();
        }
        public List<AssetEntry> GetAll()
        {
            return db.assetEntries.ToList();
        }
        public List<SubCategory> GetSubCategoriesByCategory(int CategoryId)
        {
            return db.subCategories.Where(c => c.CategoryId == CategoryId).ToList();
        }

        public int Save(DetailsCategory detailscategory)
        {
            db.detailsCategories.Add(detailscategory);
            int rowAffected = db.SaveChanges();
            return rowAffected;
        }
        public List<Category> GetCategoriesByGeneralCategory(int GeneralCategoryId)
        {
            return db.categories.Where(c => c.GeneralCategoryId == GeneralCategoryId).ToList();
        }
        public List<DetailsCategory> GetDetailsCategoryBySubCategory(int SubCategoryId)
        {
            return db.detailsCategories.Where(c => c.SubCategoryId == SubCategoryId).ToList();
        }
        public int Save(AssetEntry AssetEntry)
        {
            db.assetEntries.Add(AssetEntry);
            int rowAffected = db.SaveChanges();
            return rowAffected;
        }
    }
}
