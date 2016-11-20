using AssetTrackingSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackinSystem.DAL
{
    public  class BranchRepository
    {
        private AssetDBContext db;

        public BranchRepository()
        {
           db = new AssetDBContext();
        }
        public List<Branch> GetAllBranch()
        {
            return db.branches.ToList();
        }
        public List<Branch> GetBranchsByOrganization(int OrganizationId)
        {
            return db.branches.Where(c => c.OrganizationId == OrganizationId).ToList();
        }
    }
}
