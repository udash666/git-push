using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTrackingSystem.Models.Models;

namespace AssetTrackinSystem.DAL
{
    public class DetailsCategoryRepository
    {
         private AssetDBContext db;

        public DetailsCategoryRepository()
        {
            db = new AssetDBContext();
        }
        public List<DetailsCategory> GetAll()
        {
            return db.detailsCategories.ToList();
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

   }
}
