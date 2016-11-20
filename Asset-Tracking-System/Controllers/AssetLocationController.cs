using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using AssetTrackingSystem.Models.Models;
using AssetTrackingSystem.Models.Models.ViewModel;
using AssetTrackingSystem.BLL;
using AutoMapper;

namespace Asset_Tracking_System.Controllers
{
    public class AssetLocationController : Controller
    {
        private AssetLocationManager _AssetLocationManager;
        public AssetLocationController()
        {
            _AssetLocationManager = new AssetLocationManager();
        }
        AssetDBContext db = new AssetDBContext();
        //
        // GET: /AssetLocation/
        public ActionResult Create()
        {
            var OrganizationAssetLocation = db.assetLocations.SingleOrDefault(m => m.Id == 1);
            var BranchAssetLocation = db.assetLocations.SingleOrDefault(m => m.Id == 1);

            var organizationSelectListItems = OrganizationSelectListItems();
            var branchSelectListItems = BranchSelectListItems();
            var  AssetLocationVM = new  AssetLocationVM();
   
            AssetLocationVM.Organizations = organizationSelectListItems;
            AssetLocationVM.Branches = branchSelectListItems;
            
            return View(AssetLocationVM);
        }
        [HttpPost]
        public ActionResult Create(AssetLocationVM AssetLocationVM)
        {
                AssetLocation assetLocation = Mapper.Map<AssetLocation>(AssetLocationVM);
                bool isSaved = _AssetLocationManager.Save(assetLocation);

                if (isSaved)
                {
                    ViewBag.Message = "Save Successfully";
                   
                }
                AssetLocationVM.Organizations = OrganizationSelectListItems();
                AssetLocationVM.Branches = BranchSelectListItems();

                return View(AssetLocationVM);
        }

        private List<SelectListItem> OrganizationSelectListItems()
        {
            var Organizations = _AssetLocationManager.GetallOrganizations();
            List<SelectListItem> OrganizationSelectListItems = new List<SelectListItem>();
            OrganizationSelectListItems.Add(new SelectListItem() { Value = "", Text = "Select..." });
            foreach (var Organization in Organizations)
            {
                SelectListItem item = new SelectListItem() { Value = Organization.Id.ToString(), Text = Organization.Name };

                OrganizationSelectListItems.Add(item);
            }
            return OrganizationSelectListItems;
        }
        private List<SelectListItem> BranchSelectListItems()
        {
            var Branches = _AssetLocationManager.GetAllBranchs();
            List<SelectListItem> BranchSelectListItems = new List<SelectListItem>();
            BranchSelectListItems.Add(new SelectListItem() { Value = "", Text = "Select..." });
            foreach (var Branch in Branches)
            {
                SelectListItem item = new SelectListItem() { Value = Branch.Id.ToString(), Text = Branch.Name };

                BranchSelectListItems.Add(item);
            }
            return BranchSelectListItems;
        }
        public List<AssetLocation> AssetLocationSearchCritaria(AssetLocationSearchVM SearchVM)
        {
            var AssetLocations = db.assetLocations.AsQueryable();

            if (!String.IsNullOrEmpty(SearchVM.Name))
            {
                AssetLocations = AssetLocations.Where(c=>c.Name.ToLower().Contains(SearchVM.Name));
            }
            if (!String.IsNullOrEmpty(SearchVM.ShoerName))
            {
                AssetLocations = AssetLocations.Where(c => c.ShortName.ToLower().Contains(SearchVM.ShoerName));
            }
            return AssetLocations.OrderBy(o => o.Name).ToList();
        }
        private List<AssetLocation> GetAllAssetLocation()
        {
            var assetLocations = db.assetLocations.ToList();
            return assetLocations;
        }
        public ActionResult Index()
        {
            var AssetLocation = GetAllAssetLocation();
            return View(AssetLocation);
        }
        [HttpPost]
        public ActionResult Index(AssetLocationSearchVM AssetLocationSearchVM)
        {
            var AssetLocation = AssetLocationSearchCritaria(AssetLocationSearchVM);
            return View(AssetLocation);
        } 
        public ActionResult Edit(int ? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            AssetLocationVM ModelVM = new AssetLocationVM();
            var ExistingAssetLocation = db.assetLocations.SingleOrDefault(m => m.Id == id);
            if (ExistingAssetLocation == null)
            {
                return HttpNotFound();
            }

            return View(ExistingAssetLocation);
        }
        [HttpPost]
        public ActionResult Edit(AssetLocation assetLocation)
        {
            AssetLocationVM VM = new AssetLocationVM();
            AssetLocation AssetLocation = Mapper.Map<AssetLocation>(VM);
            db.Entry(assetLocation).State = EntityState.Modified;
            int rowAffected = db.SaveChanges();

            if (rowAffected > 0)
            {
                ViewBag.Message = "Updated Successfully!";
            }
            return View(AssetLocation);
        }  
        public ActionResult Details(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetLocation assetLocation = db.assetLocations.Find(id);
            if (assetLocation == null)
            {
                return HttpNotFound();
            }
            return View(assetLocation);
        }
        public JsonResult GetBranchByOrganization(int OrganizationId)
        {

            var AssetLocations = _AssetLocationManager
                .GetBranchsByOrganization(OrganizationId)
                .Select(c => new { Id = c.Id, Name = c.Name });

            return Json(AssetLocations, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetLocation AssetLocation = db.assetLocations.Find(id);
            if (AssetLocation == null)
            {
                return HttpNotFound();
            }
            return View(AssetLocation);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetLocation assetLocation = db.assetLocations.Find(id);
            db.assetLocations.Remove(assetLocation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public JsonResult IsShortNameExit(string ShortName)
        {
            var AssetLocationShortName = db.assetLocations.FirstOrDefault(x => x.ShortName == ShortName);
            return Json(AssetLocationShortName == null, JsonRequestBehavior.AllowGet);
        }

    }   
}