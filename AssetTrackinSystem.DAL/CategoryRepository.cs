using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTrackingSystem.Models.Models;

namespace AssetTrackinSystem.DAL
{
    public class CategoryRepository
    {
         private AssetDBContext db;

        public CategoryRepository()
        {
            db = new AssetDBContext();
        }
        public List<Category> GetAll()
        {
            return db.categories.ToList();
        }  
        public List<Category> GetCategoriesByGeneralCategory(int generalCategoryId)
        {
            return db.categories.Where(c => c.GeneralCategoryId == generalCategoryId).ToList();
        }
    }
}
