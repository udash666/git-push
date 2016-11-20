using System.Collections.Generic;
using System.Web.Mvc;

namespace AssetTrackingSystem.Models.Models.ViewModel
{
    public class BranchEditVM
    {
        public Branch Branch { get; set; }
        public List<SelectListItem> Organizations { get; set; }
    }
}