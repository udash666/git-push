using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetTrackingSystem.BLL;
using Asset_Tracking_System.Models.ViewModel;
using AssetTrackingSystem.Models.Models;
using AutoMapper;
using System.Net;
using System.Data.Entity;
namespace Asset_Tracking_System.Controllers
{
    public class DetailsCategoryController : Controller
    {
        private DetailsCategoryManager _DetailsCategoryManager;
        private CategoryManager _CategoryManager;
        public DetailsCategoryController()
        {
            _DetailsCategoryManager = new DetailsCategoryManager();
            _CategoryManager = new CategoryManager();
        }
        AssetDBContext db = new AssetDBContext();
        //
        // GET: /DetailsCategory/
        public ActionResult Create()
        {
            DetailsCategoryCreateVM ModelVM = new DetailsCategoryCreateVM();
            ModelVM.Categories = CategorySelectListItems();
            ModelVM.GeneralCategories = GeneralCategorySelectListItems();
            ModelVM.SubCategories = SubCategorySelectListItems();
            return View(ModelVM);
        }
        private List<SelectListItem> GeneralCategorySelectListItems()
        {
            var generalCategories =  _DetailsCategoryManager.GetAllGeneralCategories();
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
            var Categories =   _DetailsCategoryManager.GetAllCategories();
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
            var SubCategories =  _DetailsCategoryManager.GetAllSubCategoris();
            List<SelectListItem> SubCategorySelectListItems = new List<SelectListItem>();
            SubCategorySelectListItems.Add(new SelectListItem() { Value = "", Text = "Select..." });
            foreach (var SubCategory in SubCategories)
            {
                SelectListItem item = new SelectListItem() { Value = SubCategory.Id.ToString(), Text = SubCategory.subCategory};

                SubCategorySelectListItems.Add(item);
            }
            return SubCategorySelectListItems;
        }
        public JsonResult GetSubCategoriesByCategory(int CategoryId)
        {

            var subcategories = _DetailsCategoryManager
                .GetSubCategoriesByCategory(CategoryId)
                .Select(c => new { Id = c.Id, Name = c.subCategory });

            return Json(subcategories, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCategoriesByGeneralCategory(int GeneralCategoryId)
        {

            var categories = _CategoryManager
                 .GetCategoriesByGeneralCategory(GeneralCategoryId)
                .Select(c => new { Id = c.Id, Name = c.Name });

            return Json(categories, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Create(DetailsCategoryCreateVM ModelVM)
        {
            DetailsCategory DetailsCategory = Mapper.Map<DetailsCategory>(ModelVM);
            if (ModelState.IsValid)
            {
                bool isSaved = _DetailsCategoryManager.Save(DetailsCategory);
                if (isSaved)
                {
                    ViewBag.Message = "Save Successfully!";
                }

                ModelVM.Categories = CategorySelectListItems();
                ModelVM.GeneralCategories = GeneralCategorySelectListItems();
                ModelVM.SubCategories = SubCategorySelectListItems();
            }
            return View(ModelVM);
        }
        public ActionResult Index()
        {
            var detailsCategory = _DetailsCategoryManager.GetAllDetailsCategory();
            return View(detailsCategory);
        }
        [HttpPost]
        public ActionResult Index(DetailsCategorySearchVM ModelVM)
        {
            var detailsCategory = DetailsCategorySearchCritaria(ModelVM);
            return View(detailsCategory);
        }
        public List<DetailsCategory> DetailsCategorySearchCritaria(DetailsCategorySearchVM SearchVM)
        {

            var detailsCategories = db.detailsCategories.AsQueryable();

            if (!String.IsNullOrEmpty(SearchVM.detailsCategory))
            {
                detailsCategories = detailsCategories.Where(c => c.detailsCategory.ToLower().Contains(SearchVM.detailsCategory));
            }
            if (!String.IsNullOrEmpty(SearchVM.Code))
            {
                detailsCategories = detailsCategories.Where(c => c.Code.ToLower().Contains(SearchVM.Code));
            }
            return detailsCategories.OrderBy(o => o.detailsCategory).ToList();
        }
        public ActionResult Edit(int ? id)
        {
             if (id == null)
            {
                return HttpNotFound();
            }
             DetailsCategoryCreateVM ModelVM = new DetailsCategoryCreateVM();
             var Existing = db.detailsCategories.SingleOrDefault(m => m.Id == id);
            if (Existing == null)
            {
                return HttpNotFound();
            }
           
            return View(Existing);
        }
        [HttpPost]
        public ActionResult Edit(DetailsCategory ModelVM)
        {
            DetailsCategoryCreateVM Vm = new DetailsCategoryCreateVM();
            DetailsCategory DetailsCategory = Mapper.Map<DetailsCategory>(Vm);
            db.Entry(ModelVM).State = EntityState.Modified;
            int rowAffected = db.SaveChanges();

            if (rowAffected > 0)
            {
                ViewBag.Message = "Updated Successfully!";
            }
            return View(DetailsCategory);
        }
        public ActionResult Details(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailsCategory DetailsCategory = db.detailsCategories.Find(id);
            if (DetailsCategory == null)
            {
                return HttpNotFound();
            }
            return View(DetailsCategory);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailsCategory detailscategory = db.detailsCategories.Find(id);
            if (detailscategory == null)
            {
                return HttpNotFound();
            }
            return View(detailscategory);
        }

        // POST: /Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetailsCategory detailscategory = db.detailsCategories.Find(id);
            db.detailsCategories.Remove(detailscategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}