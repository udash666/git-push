using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using AssetTrackingSystem.Models.Models;
using AssetTrackingSystem.Models.Models.ViewModel;
using AutoMapper;
 

namespace Asset_Tracking_System.Controllers
{
    public class GeneralCategoryController : Controller
    {
        AssetDBContext db = new AssetDBContext();
        
        //
        // GET: /GeneralCategory/
        public ActionResult Create(int? id)
        {
            var model = new GeneralCategoryCreateVM();
            model.generalCategories = db.generalCategories.ToList();

            return View(model);
        }
         

        [HttpPost]
        public ActionResult Create(GeneralCategoryCreateVM ModelVM)
        {
            if (ModelState.IsValid)
            {
                GeneralCategory generalCategory = Mapper.Map<GeneralCategory>(ModelVM);
                db.generalCategories.Add(generalCategory);
                int rowAeffected = db.SaveChanges();
                if (rowAeffected > 0 )
                {
                    ViewBag.Message = "Saved Successfully!";
                }
            }

            return View(ModelVM);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var ExistinGeneralCategory = db.generalCategories.SingleOrDefault(m => m.Id == id);
            if (ExistinGeneralCategory == null)
            {
                return HttpNotFound();
            }

            return View(ExistinGeneralCategory);
        }
        [HttpPost]
        public ActionResult Edit(GeneralCategory generalCategory)
        {

                 db.generalCategories.Attach(generalCategory);
                 db.Entry(generalCategory).State = EntityState.Modified;
                  int rowAeffected = db.SaveChanges();
             
                 if (rowAeffected > 0)
                 {
                     ViewBag.Message = "Updated Successfully!";
                 }
               
            
            return View(generalCategory);
        }
        private List<GeneralCategory> GetAllGeneralCategory()
        {
            var generalCategory = db.generalCategories.ToList();
            return generalCategory;
        }
        public ActionResult Index()
        {
            var GeneralCategoryList = GetAllGeneralCategory();
            return View(GeneralCategoryList);
        }   
        [HttpPost]
        public ActionResult Index(GeneralCategorySearchVM SearchVM)
        {
            var GeneralCategories = GeneralCategorySearchCritaria(SearchVM);
            return View(GeneralCategories);
        }
        public List<GeneralCategory> GeneralCategorySearchCritaria(GeneralCategorySearchVM SearchVM)
        {
            var GeneraCategories = db.generalCategories.AsQueryable();
            if(!string.IsNullOrEmpty(SearchVM.Name))
            {
                GeneraCategories = GeneraCategories.Where(c=>c.Name.ToLower().Contains(SearchVM.Name.ToLower()));
            }
            if(!string.IsNullOrEmpty(SearchVM.Code))
            {
                GeneraCategories = GeneraCategories.Where(c => c.Code.ToLower().Contains(SearchVM.Code.ToLower()));
            }
            return GeneraCategories.OrderBy(o => o.Name).ToList();
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralCategory generalCategory = db.generalCategories.Find(id);
            if (generalCategory == null)
            {
                return HttpNotFound();
            }
            return View(generalCategory);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralCategory GeneralCategory = db.generalCategories.Find(id);
            if (GeneralCategory == null)
            {
                return HttpNotFound();
            }
            return View(GeneralCategory);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GeneralCategory GeneralCategory = db.generalCategories.Find(id);
            db.generalCategories.Remove(GeneralCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}