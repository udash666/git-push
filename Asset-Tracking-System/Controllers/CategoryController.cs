using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using System.Net;
using System.Data.Entity;
using AssetTrackingSystem.Models.Models;
using AssetTrackingSystem.Models.Models.ViewModel;

namespace Asset_Tracking_System.Controllers
{
    public class CategoryController : Controller
    {

        AssetDBContext db = new AssetDBContext();
        // GET: /Category/
        public ActionResult Create(int ? id)
        {
            var GeneralCategoryCategory = db.categories.SingleOrDefault(m => m.Id == 1);
            var Model = new CategoryCreateVM();
            Model.Categories = db.categories.ToList();
            var GeneralCategorySelectListItems = GetAllGeneralCategorySelectListItems();
            Model.GeneralCategories = GeneralCategorySelectListItems;
            return View(Model);
        }
        private List<SelectListItem> GetAllGeneralCategorySelectListItems()
        {
            var GeneralCategory = db.generalCategories.ToList();
            List<SelectListItem> GeneralCategorySelectListItems = new List<SelectListItem>();
            GeneralCategorySelectListItems.Add(new SelectListItem() { Value = "", Text = "Select..." });

            foreach (var generalCategory in GeneralCategory)
            {
                GeneralCategorySelectListItems.Add(new SelectListItem()
                {
                    Value = generalCategory.Id.ToString(),
                    Text = generalCategory.Name
                });
            }
            return GeneralCategorySelectListItems;
        }
        [HttpPost]
        public ActionResult Create(CategoryCreateVM CategoryCreateVM)
        {
            if (ModelState.IsValid)
            {
                Category category = Mapper.Map<Category>(CategoryCreateVM);
                db.categories.Add(category);
                int rowAeffected = db.SaveChanges();
                if (rowAeffected > 0)
                {
                    ViewBag.Message = "Save Successfully !";
                }
                CategoryCreateVM.GeneralCategories = GetAllGeneralCategorySelectListItems();
            }
            return View(CategoryCreateVM);
        }
        
        public ActionResult Index()
        {
            var categories = GetAllCategory();
            return View(categories);
        }
        private List<Category> GetAllCategory()
        {
            var Categories = db.categories.ToList();
            return Categories; 
        }
        [HttpPost]
        public ActionResult Index(CategorySearchVM CategorySearchVM)
        {
            var Categories = CategorySearchCritaria(CategorySearchVM);
            return View(Categories);
        }
        public List<Category> CategorySearchCritaria(CategorySearchVM SearchVM)
        {
            var Categories = db.categories.AsQueryable();
            if (!string.IsNullOrEmpty(SearchVM.Name))
            {
                Categories = Categories.Where(c => c.Name.ToLower().Contains(SearchVM.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(SearchVM.Code))
            {
                Categories = Categories.Where(c => c.Code.ToLower().Contains(SearchVM.Code.ToLower()));
            }
            return Categories.OrderBy(o => o.Name).ToList();
        }
        public ActionResult Details(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category Category = db.categories.Find(id);
            if (Category == null)
            {
                return HttpNotFound();
            }
            return View(Category);
        }
        public ActionResult Edit(int ? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            CategoryCreateVM ModelVm = new CategoryCreateVM();
            var ExistinCategory = db.categories.SingleOrDefault(m => m.Id == id);
            if (ExistinCategory == null)
            {
                return HttpNotFound();
            }

            return View(ExistinCategory);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            CategoryCreateVM ModelVm  = new CategoryCreateVM();
            Category Category = Mapper.Map<Category>(ModelVm);
            db.Entry(category).State = EntityState.Modified;
            int rowAeffected = db.SaveChanges();

            if (rowAeffected > 0)
            {
                ViewBag.Message = "Updated Successfully!";
            }
            return View(Category);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category Category = db.categories.Find(id);
            if (Category == null)
            {
                return HttpNotFound();
            }
            return View(Category);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category Category = db.categories.Find(id);
            db.categories.Remove(Category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}