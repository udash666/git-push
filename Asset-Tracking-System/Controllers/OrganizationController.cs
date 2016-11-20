using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssetTrackingSystem.Models.Models;
using AssetTrackingSystem.Models.Models.ViewModel;

namespace Asset_Tracking_System.Controllers
{
    public class OrganizationController : Controller
    {
        AssetDBContext db = new AssetDBContext();
        //
        // GET: /Organization/
        public ActionResult Create(int ? id )
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Organization organization)
        {

           
            if (ModelState.IsValid)
            {
                db.organizations.Add(organization);

                int rowAffected = db.SaveChanges();

                if (rowAffected > 0)
                {
                    ViewBag.Message = "Save Successfully";
                }

            }
            return View(organization);

        }

        public ActionResult Edit(int ? id)
        {
            if (id == null)
            {
                return HttpNotFound(); 
            }
            var ExistingOrganization = db.organizations.SingleOrDefault( c=> c.Id == id);
            if (ExistingOrganization == null)
            {
                return HttpNotFound();
            }

            return View(ExistingOrganization);
        }

        [HttpPost]
        public ActionResult Edit(Organization organization)
        {
            db.organizations.Attach(organization);
            db.Entry(organization).State = EntityState.Modified;
            int rowAffected = db.SaveChanges();

            if (rowAffected > 0)
            {
                ViewBag.Message = "Updated Successfully!";
            }
            return View(organization);
        }
        public ActionResult Details(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }
        private List<Organization> GetAllOrganizations()
        {
            var organizations = db.organizations.ToList();
            return organizations;

        }
        public ActionResult Index()
        {
            var org = GetAllOrganizations();
            return View(org);
        }
      
        [HttpPost]
        public ActionResult Index(OrganizationSearchVM organizationSearchCriteria)
        {
            var Organizations = GetOrganizationBySearchCriteria(organizationSearchCriteria);
            return View(Organizations);
        }
       
        public List<Organization> GetOrganizationBySearchCriteria(OrganizationSearchVM SearchVM)
        {
            var Organizations = db.organizations.AsQueryable();


            if (!String.IsNullOrEmpty(SearchVM.Name))
            {
                Organizations = Organizations.Where(c => c.Name.ToLower().Contains(SearchVM.Name.ToLower()));
            }

            if (!String.IsNullOrEmpty(SearchVM.Code))
            {
                Organizations = Organizations.Where(c => c.Code.Equals(SearchVM.Code));
            }

            if (!String.IsNullOrEmpty(SearchVM.Location))
            {
                Organizations = Organizations.Where(c => c.Location.ToLower().Contains(SearchVM.Location));
            }

            return Organizations.OrderBy(o => o.Name).ToList();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization Organization = db.organizations.Find(id);
            if (Organization == null)
            {
                return HttpNotFound();
            }
            return View(Organization);
        }
        // POST: /Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
             Organization Organization = db.organizations.Find(id);
            db.organizations.Remove(Organization);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public JsonResult IsNameExit(string Name)
        {
            var OrgnizationName = db.organizations.FirstOrDefault(x => x.Name == Name);
            return Json(OrgnizationName == null, JsonRequestBehavior.AllowGet);
        }
        public JsonResult IsShortNameExit(string ShortName)
        {
            var OrganizationShortName = db.organizations.FirstOrDefault(x => x.ShortName == ShortName);
            return Json(OrganizationShortName == null, JsonRequestBehavior.AllowGet);
        }
        public JsonResult IsCodeExit(string Code)
        {
            var OrganizationCode = db.organizations.FirstOrDefault(x => x.Code == Code);
            return Json(OrganizationCode == null, JsonRequestBehavior.AllowGet);
        }
    }
}