using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTrackingSystem.Models.Models;

namespace AssetTrackinSystem.DAL
{
    public class OrganizationRepository
    {
        private  AssetDBContext db;

        public OrganizationRepository()
        {
            db = new AssetDBContext();
        }
        public List<Organization>GetAllOrganization()
        {
            return db.organizations.ToList();
        }
    }
}
