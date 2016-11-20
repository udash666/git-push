using AssetTrackingSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackinSystem.DAL
{
    public class AssetLocationRepository
    {
        private AssetDBContext db;

        public AssetLocationRepository()
        {
            db =  new  AssetDBContext();
        }
        public List<AssetLocation>GetAllAssetLocations()
        {
            return db.assetLocations.ToList();
        }
        public int Save(AssetLocation assetlocation)
        {

            db.assetLocations.Add(assetlocation);
            int rowAffected = db.SaveChanges();
            return rowAffected;
        }
    }
}
