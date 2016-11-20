using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AssetTrackingSystem.Models.Models;
using System.Web.Mvc;

namespace AssetTrackinSystem.DAL
{
    public class SubCategoryRepository
    {
        private AssetDBContext db;
        public SubCategoryRepository()
        {
            db = new AssetDBContext();
        }
        public int Save(SubCategory subcategory)
        {
            db.subCategories.Add(subcategory);
            int rowAeffected = db.SaveChanges();
            return rowAeffected;
        }

        public int Update(SubCategory subcategory)
        {
            db.subCategories.Attach(subcategory);
            db.Entry(subcategory).State = EntityState.Modified;
            int update =  db.SaveChanges();
            return update;
        }
        public List<SubCategory> GetAllSubCategory()
        {
            return db.subCategories.ToList();
        }

        public List<SubCategory> GetSubCategoriesByCategory(int CategoryId)
        {
            return db.subCategories.Where(c => c.CategoryId == CategoryId).ToList();
        }
     
        public void Dispose()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }
    }
}
