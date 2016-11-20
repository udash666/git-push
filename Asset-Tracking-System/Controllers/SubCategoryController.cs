using System;
using AssetTrackingSystem.BLL;
using AssetTrackinSystem.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTrackingSystem.Models.Models;
using AssetTrackingSystem.Models.Models.ViewModel;
using Asset_Tracking_System.Models.ViewModel;
using AutoMapper;
using System.Net;
using System.Data.Entity;

namespace Asset_Tracking_System.Controllers
{
    public class SubCategoryController : Controller
    {
        private CategoryManager _CategoryManager;

        public SubCategoryController()
        {
            _CategoryManager = new CategoryManager();
        }
        //
        // GET: /SubCategory/
        public AssetDBContext db = new AssetDBContext();
        public ActionResult Create()
        {

            SubCategoryCreateVM ModelVM = new SubCategoryCreateVM();
            ModelVM.Categories = CategorySelectListItems();
            ModelVM.GeneralCategories = GeneralCategorySelectListItems();
            return View(ModelVM);
        }

        private List<SelectListItem> GeneralCategorySelectListItems()
        {
            var generalCategories = _CategoryManager.GetAllGeneralCategories();
            List<SelectListItem> generalCategoriesSelectListItems = new List<SelectListItem>();
            generalCategoriesSelectListItems.Add(new SelectListItem() { Value = "", Text = "Select..." });

            foreach (var generalCategory in generalCategories)
            {

                SelectListItem item = new SelectListItem() { Value = generalCategory.Id.ToString(), Text = generalCategory.Name };

                generalCategoriesSelectListItems.Add(item);

            }
            return generalCategoriesSelectListItems;
        }
        private List<SelectListItem> CategorySelectListItems()
        {
            var Categories = _CategoryManager.GetAllCategories();
            List<SelectListItem> CategorySelectListItems = new List<SelectListItem>();
            CategorySelectListItems.Add(new SelectListItem() { Value = "", Text = "Select..." });
            foreach (var Category in Categories)
            {
                SelectListItem item = new SelectListItem() { Value = Category.Id.ToString(), Text = Category.Name };

                CategorySelectListItems.Add(item);
            }
            return CategorySelectListItems;
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "GeneralCategoryId,CategoryId,subCategory,Code,Description")] SubCategoryCreateVM ModelVM)
        {

            SubCategory subcategory = Mapper.Map<SubCategory>(ModelVM);
            if (ModelState.IsValid)
            {
                bool isSaved = _CategoryManager.Save(subcategory);
                if (isSaved)
                {
                    ViewBag.Message = "Save Successfully!";
                }

                ModelVM.Categories = CategorySelectListItems();
                ModelVM.GeneralCategories = GeneralCategorySelectListItems();
            }
            return View(ModelVM);

        }
        public JsonResult GetCategoriesByGeneralCategory(int generalCategoryId)
        {

            var categories = _CategoryManager
                .GetCategoriesByGeneralCategory(generalCategoryId)
                .Select(c => new { Id = c.Id, Name = c.Name });

            return Json(categories, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            var AssetLocation = _CategoryManager.GetAllSubCategory();
            return View(AssetLocation);
        }
        public List<SubCategory> SubCategorySearchCritaria(SubCategorySearchVM SearchVM)
        {

            var subCategories = db.subCategories.AsQueryable();

            if (!String.IsNullOrEmpty(SearchVM.subCategory))
            {
                subCategories = subCategories.Where(c => c.subCategory.ToLower().Contains(SearchVM.subCategory));
            }
            if (!String.IsNullOrEmpty(SearchVM.Code))
            {
                subCategories = subCategories.Where(c => c.Code.ToLower().Contains(SearchVM.Code));
            }
            return subCategories.OrderBy(o => o.subCategory).ToList();
        }
        [HttpPost]
        public ActionResult Index(SubCategorySearchVM SubCategorySearchVM)
        {
            var SubCategories = SubCategorySearchCritaria(SubCategorySearchVM);
            return View(SubCategories);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subcategory = db.subCategories.Find(id);
            if (subcategory == null)
            {
                return HttpNotFound();
            }
            return View(subcategory);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var ExistingSubCategory = db.subCategories.SingleOrDefault(m => m.Id == id);
            if (ExistingSubCategory == null)
            {
                return HttpNotFound();
            }

            return View(ExistingSubCategory);

        }
        [HttpPost]
        public ActionResult Edit(SubCategoryCreateVM SubCategory)
        {
            SubCategory subcategory = Mapper.Map<SubCategory>(SubCategory);
            bool isUpdate = _CategoryManager.Update(subcategory);
            if (isUpdate)
            {
                ViewBag.Message = "Updated Successfully!";
            }
            return View(SubCategory);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory SubCategory = db.subCategories.Find(id);
            if (SubCategory == null)
            {
                return HttpNotFound();
            }
            return View(SubCategory);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCategory SubCategory = db.subCategories.Find(id);
            db.subCategories.Remove(SubCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

