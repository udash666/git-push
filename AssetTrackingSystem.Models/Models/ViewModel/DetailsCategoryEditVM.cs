using AssetTrackingSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asset_Tracking_System.Models.ViewModel
{
    public class DetailsCategoryEditVM
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
    }
}