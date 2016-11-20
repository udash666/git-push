using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AssetTrackingSystem.Models.Models.ViewModel
{
    public class SubCategoryCreateVM
    {
        public int Id { get; set; }


        public int GeneralCategoryId { get; set; }
     

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } 

        [Required]  
        [Display(Name = "Sub Category/Model")]
        public string subCategory { get; set; }

        [Required]
        public string Code { get; set; }

        public string Description { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public List<SelectListItem> GeneralCategories { get; set; }
    }
}