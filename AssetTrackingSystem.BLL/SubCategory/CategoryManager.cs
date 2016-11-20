using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTrackingSystem.Models.Models;
using AssetTrackingSystem.Models.Models.ViewModel;
using AssetTrackinSystem.DAL;

namespace AssetTrackingSystem.BLL
{
    public class CategoryManager
    {
        private GeneralCategoryRepository _GeneralCategoryRepository;
        private CategoryRepository _CategoryRepository;
        private SubCategoryRepository _SubCategoryRepository;
      

        public CategoryManager()
        {
            _GeneralCategoryRepository = new GeneralCategoryRepository();
            _CategoryRepository = new CategoryRepository();
            _SubCategoryRepository = new SubCategoryRepository();
        }
        public List<GeneralCategory> GetAllGeneralCategories()
        {
            return _GeneralCategoryRepository.GetAllGeneralCategory();
        }
        public List<Category> GetAllCategories()
        {
            return _CategoryRepository.GetAll();
        }
        public List<Category> GetCategoriesByGeneralCategory(int generalCategoryId)
        {
            return _CategoryRepository.GetCategoriesByGeneralCategory(generalCategoryId);
        }
       public bool Save(SubCategory subcategory)
        {
            int rowAffected = _SubCategoryRepository.Save(subcategory);
            bool isSaved = rowAffected > 0;
            return isSaved;
        }
        public List<SubCategory>GetAllSubCategory()
       {
           return _SubCategoryRepository.GetAllSubCategory();
       }
        public bool Update(SubCategory subcategory)
        {
            int rowAffected = _SubCategoryRepository.Update(subcategory);
            bool isUpdate = rowAffected > 0;
            return isUpdate;
        }
         
    }
}
