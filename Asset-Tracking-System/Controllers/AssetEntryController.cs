using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTrackingSystem.Models.Models;
using Asset_Tracking_System.Models.ViewModel;
using AssetTrackingSystem.BLL;
using AssetTrackinSystem.DAL;
using Asset_Tracking_System.Models;
using AutoMapper;
using System.Data.Entity;
using System.Net;

namespace Asset_Tracking_System.Controllers
{

    public class AssetEntryController : Controller
    {
        private DetailsCategoryManager _DetailsCategoryManager;
        private CategoryManager _CategoryManager;
        private AssetEntryManager _AssetEntryManager;

        public AssetEntryController()
        {
            _AssetEntryManager = new AssetEntryManager();
            _CategoryManager = new CategoryManager();
            _DetailsCategoryManager = new DetailsCategoryManager();
        }

        AssetDBContext db = new AssetDBContext();
        public ActionResult Create()
        {
            AssetEntryCreateVM ModelVM = new AssetEntryCreateVM();

            ModelVM.GeneralCategories = GeneralCategorySelectListItems();
            ModelVM.Categories = CategorySelectListItems();
            ModelVM.SubCategories = SubCategorySelectListItems();
            ModelVM.DetailsCategories = DetailsSelectListItems();
            return View(ModelVM);
        }

        [HttpPost]
        public ActionResult Create(AssetEntryCreateVM ModelVM)
        {
            AssetEntry AssetEntry = Mapper.Map<AssetEntry>(ModelVM);
            bool IsSave = _AssetEntryManager.Save(AssetEntry);
            if(IsSave)
            {
                return RedirectToAction("Index");
            }
            ModelVM.GeneralCategories = GeneralCategorySelectListItems();
            ModelVM.Categories = CategorySelectListItems();
            ModelVM.SubCategories = SubCategorySelectListItems();
            ModelVM.DetailsCategories = DetailsSelectListItems();
            return View(ModelVM);
        }

        private List<SelectListItem> GeneralCategorySelectListItems()
        {
            var generalCategories = _DetailsCategoryManager.GetAllGeneralCategories();
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
            var Categories = _DetailsCategoryManager.GetAllCategories();
            List<SelectListItem> CategorySelectListItems = new List<SelectListItem>();
            CategorySelectListItems.Add(new SelectListItem() { Value = "", Text = "Select..." });
            foreach (var Category in Categories)
            {
                SelectListItem item = new SelectListItem() { Value = Category.Id.ToString(), Text = Category.Name };

                CategorySelectListItems.Add(item);
            }
            return CategorySelectListItems;
        }

        private List<SelectListItem> SubCategorySelectListItems()
        {
            var SubCategories = _DetailsCategoryManager.GetAllSubCategoris();
            List<SelectListItem> SubCategorySelectListItems = new List<SelectListItem>();
            SubCategorySelectListItems.Add(new SelectListItem() { Value = "", Text = "Select..." });
            foreach (var SubCategory in SubCategories)
            {
                SelectListItem item = new SelectListItem() { Value = SubCategory.Id.ToString(), Text = SubCategory.subCategory };

                SubCategorySelectListItems.Add(item);
            }
            return SubCategorySelectListItems;
        }
        private List<SelectListItem> DetailsSelectListItems()
        {
            var DetailsCategories = _AssetEntryManager.GetAllDetailsCategory();
            List<SelectListItem> DetailsCategorySelectListItems = new List<SelectListItem>();
            DetailsCategorySelectListItems.Add(new SelectListItem() { Value = "", Text = "Select..." });
            foreach (var DetailsCategory in DetailsCategories)
            {
                SelectListItem item = new SelectListItem() { Value = DetailsCategory.Id.ToString(), Text = DetailsCategory.detailsCategory };

                DetailsCategorySelectListItems.Add(item);
            }
            return DetailsCategorySelectListItems;
        }
        //
        // GET: /AssetEntry/
        public ActionResult Index()
        {
            var AssetEntry = _AssetEntryManager.GetAllAssetEntries();
            return View(AssetEntry);
        }

        [HttpPost]
        public ActionResult Index(AssetEntrySearchVM ModelVm)
        {
            var AssetEntries = AssetEntrySearchCritaria(ModelVm);
            return View(AssetEntries);
        }

        public List<AssetEntry> AssetEntrySearchCritaria(AssetEntrySearchVM SearchVM)
        {
            var AssetEntries = db.assetEntries.AsQueryable();
            if(!string.IsNullOrEmpty(SearchVM.Price))
            {
                AssetEntries = AssetEntries.Where(c => c.Price.ToLower().Contains(SearchVM.Price));
            }
            if(!string.IsNullOrEmpty(SearchVM.Serial))
            {
                AssetEntries = AssetEntries.Where(c => c.Serial.ToLower().Contains(SearchVM.Serial)); 
            }
            return AssetEntries.OrderBy(o => o.PurchaseDate).ToList();
        }

        public JsonResult GetCategoriesByGeneralCategory(int GeneralCategoryId)
        {

            var categories = _CategoryManager
                 .GetCategoriesByGeneralCategory(GeneralCategoryId)
                .Select(c => new { Id = c.Id, Name = c.Name });

            return Json(categories, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSubCategoriesByCategory(int CategoryId)
        {

            var subcategories = _DetailsCategoryManager
                .GetSubCategoriesByCategory(CategoryId)
                .Select(c => new { Id = c.Id, Name = c.subCategory });

            return Json(subcategories, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDetailsCategoriesBySubCategory(int subCategoryId)
        {

            var detailscategories = _AssetEntryManager
                  .GetDetailsCategoriesBySubCategory(subCategoryId)
                .Select(c => new { Id = c.Id, Name = c.detailsCategory});

            return Json(detailscategories, JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult Edit(int ? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            AssetEntryCreateVM ModelVM = new AssetEntryCreateVM();
            var ExistingAssetEntry = db.assetEntries.SingleOrDefault(m => m.Id == id);
            if (ExistingAssetEntry == null)
            {
                return HttpNotFound();
            }

            return View(ExistingAssetEntry);
        }
        [HttpPost]
        public ActionResult Edit(AssetEntry assetEntry)
        {
            AssetEntryCreateVM VM = new AssetEntryCreateVM();
            AssetEntry AssetEntry = Mapper.Map<AssetEntry>(VM);
            db.Entry(assetEntry).State = EntityState.Modified;
            int Row = db.SaveChanges();
            if (Row >0)
            {
                @ViewBag.Message = "Update Successfully";
            }
            return View(AssetEntry);
        }
        public ActionResult Details(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetEntry AssetEntry = db.assetEntries.Find(id);
            if (AssetEntry == null)
            {
                return HttpNotFound();
            }
            return View(AssetEntry);
        }
        public ActionResult Delete(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetEntry AssetEntry = db.assetEntries.Find(id);
            if (AssetEntry == null)
            {
                return HttpNotFound();
            }
            return View(AssetEntry);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetEntry assetEntry = db.assetEntries.Find(id);
            db.assetEntries.Remove(assetEntry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}