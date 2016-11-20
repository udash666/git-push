using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using AssetTrackingSystem.Models.Models;
using AssetTrackingSystem.Models.Models.ViewModel;

namespace Asset_Tracking_System.Controllers
{
    public class BranchController : Controller
    {
         AssetDBContext db = new AssetDBContext();


        public ActionResult Create()
        {

            var organizationBranch = db.branches.SingleOrDefault(m => m.Id == 1);


            var organizationSelectListItems = GetOrganizationSelectListItems();

            var BranchCreateVM = new BranchCreateVM();

            BranchCreateVM.Organizations = organizationSelectListItems;


            return View(BranchCreateVM);
        }


        private List<SelectListItem> GetOrganizationSelectListItems()
        {
            var organizations = db.organizations.ToList();
            List<SelectListItem> organizationSelectListItems = new List<SelectListItem>();
            organizationSelectListItems.Add(new SelectListItem() {Value = "", Text = "Select..."});

            foreach (var organization in organizations)
            {
                organizationSelectListItems.Add(new SelectListItem()
                {
                    Value = organization.Id.ToString(),
                    Text = organization.Name
                });
            }
            return organizationSelectListItems;
        }
             [HttpPost]
             public ActionResult Create(BranchCreateVM BranchCreateVM)
             {
                 if (ModelState.IsValid)
                 {
                     var Branch = BranchCreateVM.Branch;
                     db.branches.Add(Branch);

                     int rowAffected = db.SaveChanges();
                     if (rowAffected > 0)
                     {
                         ViewBag.Message = "Save Successfully";
                     }

                     BranchCreateVM.Organizations = GetOrganizationSelectListItems();
                 }
                 return View(BranchCreateVM);
             }
           public ActionResult Edit(int ? id)
           {
               if (id == null)
               {
                   return HttpNotFound();
               }
               var ExistingBranch = db.branches.SingleOrDefault(m => m.Id == id);
               if (ExistingBranch == null)
               {
                   return HttpNotFound();
               }

               return View(ExistingBranch);
 
           }
           [HttpPost]
           public ActionResult Edit(Branch branch)
           {
               db.branches.Attach(branch);
               db.Entry(branch).State = EntityState.Modified;
               int rowAffected = db.SaveChanges();

               if (rowAffected > 0)
               {
                   ViewBag.Message = "Updated Successfully!";
               }
               return View(branch);
           }
           public ActionResult Details(int? id)
           {
               if (id == null)
               {
                   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               }
               Branch branch = db.branches.Find(id);
               if (branch == null)
               {
                   return HttpNotFound();
               }
               return View(branch);
           }
           private List<Branch> GetAllBranch()
           {
               var barnches = db.branches.ToList();
               return barnches;
           }
            public ActionResult Index()
           {
               var branch = GetAllBranch();
               return View(branch);
           }
           public List<Branch> BranchSearchCritaria(BranchSearchVM SearchVM)
            {
                var Branches = db.branches.AsQueryable();

                if (!String.IsNullOrEmpty(SearchVM.Name))
                {
                    Branches = Branches.Where(c => c.Name.ToLower().Contains(SearchVM.Name));
                }
               if (!String.IsNullOrEmpty(SearchVM.ShortName))
               {
                   Branches = Branches.Where(c => c.ShortName.ToLower().Contains(SearchVM.ShortName));
               }
               return Branches.OrderBy(o => o.Name).ToList();
            }
           [HttpPost]
           public ActionResult Index(BranchSearchVM BranchSearchVM)
           {
               var Branches = BranchSearchCritaria(BranchSearchVM);
               return View(Branches);
           }
           public ActionResult Delete(int? id)
           {
               if (id == null)
               {
                   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               }
               Branch branch = db.branches.Find(id);
               if (branch == null)
               {
                   return HttpNotFound();
               }
               return View(branch);
           }
           [HttpPost, ActionName("Delete")]
           [ValidateAntiForgeryToken]
           public ActionResult DeleteConfirmed(int id)
           {
               Branch Branch = db.branches.Find(id);
               db.branches.Remove(Branch);
               db.SaveChanges();
               return RedirectToAction("Index");
           }
        public JsonResult IsShortNameExit(string ShortName)
        {
            var BranchShortName = db.branches.FirstOrDefault(x => x.ShortName == ShortName);
            return  Json(BranchShortName == null , JsonRequestBehavior.AllowGet);
        }
     }
}