using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTrackinSystem.DAL;
using AssetTrackingSystem.Models.Models;

namespace AssetTrackingSystem.BLL
{
    public class DetailsCategoryManager
    {
        private GeneralCategoryRepository _GeneralCategoryRepository;
        private CategoryRepository _CategoryRepository;
        private SubCategoryRepository _SubCategoryRepository;
        private DetailsCategoryRepository _DetailsCategoryRepository;
         public DetailsCategoryManager()
        {
            _GeneralCategoryRepository = new GeneralCategoryRepository();
            _CategoryRepository = new CategoryRepository();
            _SubCategoryRepository = new SubCategoryRepository();
            _DetailsCategoryRepository = new DetailsCategoryRepository();
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
        public bool Save(DetailsCategory detailscategory)
        {
            int rowAffected =  _DetailsCategoryRepository.Save(detailscategory);
            bool isSaved = rowAffected > 0;
            return isSaved;
        }
        public List<SubCategory> GetSubCategoriesByCategory(int CategoryId)
        {
            return _DetailsCategoryRepository.GetSubCategoriesByCategory(CategoryId);
        }
        public List<Category> GetCategoriesByGeneralCategory(int GeneralCategoryId)
        {
            return _DetailsCategoryRepository.GetCategoriesByGeneralCategory(GeneralCategoryId);
        }
    }
}
