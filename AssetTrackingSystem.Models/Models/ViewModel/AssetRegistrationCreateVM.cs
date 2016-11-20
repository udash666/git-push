using AssetTrackingSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asset_Tracking_System.Models.ViewModel
{
    public class AssetRegistrationCreateVM
    {
        public int Id { get; set; }

        public int AssetId { get; set; }

        public virtual AssetEntry AssetEntry { get; set; }

        public int LocationId { get; set; }

        public virtual AssetLocation AssetLocation { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Registration By")]
        public string RegistrationBy { get; set; }

        [Required]
        [Display(Name = "Serial Number")]
        public string Serial { get; set; }

        public List<SelectListItem> Organizations { get; set; }
        public List<SelectListItem> Branches { get; set; }
        public List<SelectListItem> GeneralCategories { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}