using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTrackingSystem.Models.Models;

namespace AssetTrackinSystem.DAL
{
    public class GeneralCategoryRepository
    {
        private AssetDBContext db;

        public GeneralCategoryRepository()
        {
            db = new AssetDBContext();
        }
        public List<GeneralCategory> GetAllGeneralCategory()
        {
            return db.generalCategories.ToList();
        }
    }
}
