using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssetTrackingSystem.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Asset_Tracking_System.Models.ViewModel
{
    public class DetailsCategoryCreateVM
    {
        public int Id { get; set; }
        public int GeneralCategoryId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        [Required]
        [Display(Name = "Details Category")]
        public string detailsCategory { get; set; }
        [Required]
        [StringLength(3)]
        public string Code { get; set; }
        public string Description { get; set; }
        public List<SelectListItem> Categories { get; set; }

        public List<SelectListItem> GeneralCategories { get; set; }

        public List<SelectListItem> SubCategories { get; set; }
    }
}