using Asset_Tracking_System.Models.ViewModel;
using AssetTrackingSystem.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asset_Tracking_System.Controllers
{
    public class AssetRegistrationController : Controller
    {

        private DetailsCategoryManager _DetailsCategoryManager;
        private CategoryManager _CategoryManager;
        private AssetEntryManager _AssetEntryManager;
        private AssetRegistrationManager _AssetRegistrationManager;

        public AssetRegistrationController()
        {
            _CategoryManager = new CategoryManager();
            _AssetEntryManager = new AssetEntryManager();
            _AssetRegistrationManager = new AssetRegistrationManager();
            _DetailsCategoryManager = new DetailsCategoryManager();
        }

        public ActionResult Create()
        {
            AssetRegistrationCreateVM ModelVM = new AssetRegistrationCreateVM();
            ModelVM.GeneralCategories = GeneralCategorySelectListItems();
            ModelVM.Categories = CategorySelectListItems();
            return View(ModelVM);
        }

        public JsonResult GetCategoriesByGeneralCategory(int GeneralCategoryId)
        {

            var categories = _CategoryManager
                  .GetCategoriesByGeneralCategory(GeneralCategoryId)
                 .Select(c => new { Id = c.Id, Code = c.Code });
                 

            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult AssetIdGenerate(int AssetId)
        //{

        //    var categories = _AssetRegistrationManager
        //          .
        //         .Select(c => new { Id = c.Id, Code = c.Code });


        //    return Json(categories, JsonRequestBehavior.AllowGet);
        //}
        //
        // GET: /AssetRegistration/
        public ActionResult Index()
        {
            return View();
        }
        private List<SelectListItem> GeneralCategorySelectListItems()
        {
            var generalCategories = _DetailsCategoryManager.GetAllGeneralCategories();
            List<SelectListItem> generalCategoriesSelectListItems = new List<SelectListItem>();
            generalCategoriesSelectListItems.Add(new SelectListItem() { Value = "", Text = "Select..." });

            foreach (var generalCategory in generalCategories)
            {

                SelectListItem item = new SelectListItem() { Value = generalCategory.Id.ToString(), Text = generalCategory.Code };

                generalCategoriesSelectListItems.Add(item);

            }
            return generalCategoriesSelectListItems;
        }
        private List<SelectListItem> CategorySelectListItems()
        {
            var Categories = _DetailsCategoryManager.GetAllCategories();
            List<SelectListItem> CategorySelectListItems = new List<SelectListItem>();
            CategorySelectListItems.Add(new SelectListItem() { Value = "", Text = "Select..." });
            foreach (var Category in Categories)
            {
                SelectListItem item = new SelectListItem() { Value = Category.Id.ToString(), Text = Category.Code };

                CategorySelectListItems.Add(item);
            }
            return CategorySelectListItems;
            
        }
	}
}