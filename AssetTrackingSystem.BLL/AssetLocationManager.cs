using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTrackinSystem.DAL;
using AssetTrackingSystem.Models.Models;

namespace AssetTrackingSystem.BLL
{
    public class AssetLocationManager
    {
        private OrganizationRepository _OrganizationRepository;
        private BranchRepository _BranchRepository;
        private AssetLocationRepository _AssetLocationRepository;

        public AssetLocationManager()
        {
            _OrganizationRepository = new OrganizationRepository();
            _BranchRepository = new BranchRepository();
            _AssetLocationRepository = new AssetLocationRepository();
        }
        public List<Organization> GetallOrganizations()
        {
            return _OrganizationRepository.GetAllOrganization();
        }
        public List<Branch> GetAllBranchs()
        {
            return _BranchRepository.GetAllBranch();
        }
        public List<AssetLocation> GetAllAssetLocations()
        {
            return _AssetLocationRepository.GetAllAssetLocations();
        }
        public List<Branch> GetBranchsByOrganization(int OrganizationId)
        {
            return _BranchRepository.GetBranchsByOrganization(OrganizationId);
        }

        public bool Save(AssetLocation AssetLocation)
        {
            int rowAffected = _AssetLocationRepository.Save(AssetLocation);
            bool isSaved = rowAffected > 0;
            return isSaved;
        }
    }
}
