using Asset_Tracking_System.Models;
using AssetTrackingSystem.Models.Models;
using AssetTrackinSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem.BLL
{
    public class AssetRegistrationManager
    {
        private OrganizationRepository _OrganizationRepository;
        private BranchRepository _BranchRepository;
        private GeneralCategoryRepository _GeneralCategoryRepository;
        private CategoryRepository _CategoryRepository;
        private SubCategoryRepository _SubCategoryRepository;
        private DetailsCategoryRepository _DetailsCategoryRepository;
        private AssetEntryRepository _AssetEntryRepository;
        private AssetRegistrationRepository _AssetRegistrationRepository;

         public AssetRegistrationManager()
        {
            _OrganizationRepository = new OrganizationRepository();
            _BranchRepository = new BranchRepository();
            _GeneralCategoryRepository = new GeneralCategoryRepository();
            _CategoryRepository = new CategoryRepository();
            _AssetEntryRepository = new AssetEntryRepository();
            _AssetRegistrationRepository = new AssetRegistrationRepository();
        }

        public List<GeneralCategory> GetAllGeneralCategories()
        {
            return _GeneralCategoryRepository.GetAllGeneralCategory();
        }
        public List<Category> GetAllCategories()
        {
            return _CategoryRepository.GetAll();
        }
        public List<AssetEntry> GetAllAssetEntries()
        {
            return _AssetEntryRepository.GetAll();
        }
        public bool Save(AssetRegistration AssetRegistration)
        {
            int rowAffected = _AssetRegistrationRepository.Save(AssetRegistration);
            bool isSaved = rowAffected > 0;
            return isSaved;
        }
        public List<Branch> GetBranchesByOrganization(int OrganizationId)
        {
            return _AssetRegistrationRepository.GetBranchesByOrganizations(OrganizationId);
        }
        public List<Category> GetCategoriesByGeneralCategory(int GeneralCategoryId)
        {
            return _AssetRegistrationRepository.GetCategoriesByGeneralCategory(GeneralCategoryId);
        }
        //public List<Category> AssetIdGenerator(int AssetId)
        //{
            
        //    return 
        //}

    }
}
