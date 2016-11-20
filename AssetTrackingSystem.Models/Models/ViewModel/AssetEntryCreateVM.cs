using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssetTrackingSystem.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Asset_Tracking_System.Models.ViewModel
{
    public class AssetEntryCreateVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please select Date")]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Vendor Information")]
        public string Vendor { get; set; }

        [Display(Name = "General Category")]
        public int GeneralCategoryId { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Sub Category")]
        public int SubCategoryId { get; set; }

        [Display(Name = "Details Category")]
        public int DetailsCategoryId { get; set; }
        public virtual DetailsCategory DetaisCategory { get; set; }

        [Display(Name = "Warrenty Period")]
       
        public string WarrentyPeriod { get; set; }

        public string Price { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Serial Number")]
        public string Serial { get; set; }

        public List<SelectListItem> DetailsCategories { get; set; }
        public List<SelectListItem> SubCategories { get; set; }
        public List<SelectListItem> GeneralCategories { get; set; }
        public List<SelectListItem> Categories { get; set; }
        
    }
}