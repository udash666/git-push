using Asset_Tracking_System.Models;
using AssetTrackingSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackinSystem.DAL
{
    public class AssetRegistrationRepository
    {
           private AssetDBContext db;
        public AssetRegistrationRepository()
        {
           db = new AssetDBContext();
        }
        public List<AssetRegistration> GetAll()
        {
            return db.assetRegistrations.ToList();
        }
        public List<Category> GetCategoriesByGeneralCategory(int GeneralCategoryId)
        {
            return db.categories.Where(c => c.GeneralCategoryId == GeneralCategoryId).ToList();
        }


        public List<Branch> GetBranchesByOrganizations(int OrganizationId)
        {
            return db.branches.Where(c => c.OrganizationId == OrganizationId).ToList();
        }
        public int Save(AssetRegistration AssetRegistration)
        {
            db.assetRegistrations.Add(AssetRegistration);
            int rowAffected = db.SaveChanges();
            return rowAffected;
        }
        //public List<AssetEntry> AssetIdGenerator(Random generator, int CategoryId, int GeneralCategoryId)
        //{
        //    generator = new Random();
        //    int r = generator.Next(1, 1000000);
        //    string s = r.ToString().PadLeft(6, '0');

        //    var Category = db.assetEntries.Where(c => c.GeneralCategoryId == GeneralCategoryId).ToList();
        //    var GeneralCategory = db.assetEntries.Where(c => c.CategoryId == CategoryId).ToList();
        //    return string.Format("{0} {1});
        //}
    }
}
