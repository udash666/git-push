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
     public class AssetEntryManager
    {
        private GeneralCategoryRepository _GeneralCategoryRepository;
        private CategoryRepository _CategoryRepository;
        private SubCategoryRepository _SubCategoryRepository;
        private DetailsCategoryRepository _DetailsCategoryRepository;
        private AssetEntryRepository _AssetEntryRepository;

        public AssetEntryManager()
        {
            _GeneralCategoryRepository = new GeneralCategoryRepository();
            _CategoryRepository = new CategoryRepository();
            _SubCategoryRepository = new SubCategoryRepository();
            _DetailsCategoryRepository = new DetailsCategoryRepository();
            _AssetEntryRepository = new AssetEntryRepository();
        }
        public List<GeneralCategory> GetAllGeneralCategories()
        {
            return _GeneralCategoryRepository.GetAllGeneralCategory();
        }
        public List<Category> GetAllCategories()
        {
            return _CategoryRepository.GetAll();
        }
        public List<SubCategory> GetAllSubCategoris()
        {
            return _SubCategoryRepository.GetAllSubCategory();
        }
        public List<DetailsCategory> GetAllDetailsCategory()
        {
            return _DetailsCategoryRepository.GetAll();
        }
        public List<AssetEntry> GetAllAssetEntries()
        {
            return _AssetEntryRepository.GetAll();
        }
        public bool Save(AssetEntry AssetEntry)
        {
            int rowAffected = _AssetEntryRepository.Save(AssetEntry);
            bool isSaved = rowAffected > 0;
            return isSaved;
        }

        public  List<DetailsCategory> GetDetailsCategoriesBySubCategory(int subcategoryId)
        {
            return _AssetEntryRepository.GetDetailsCategoryBySubCategory(subcategoryId);
        }
    }
}
