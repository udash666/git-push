using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AssetTrackingSystem.Models.Models.ViewModel
{
    public class CategoryCreateVM
    {
        public string Id { get; set; }
        
        public int GeneralCategoryId { get; set; }
        public virtual GeneralCategory GeneralCategory { get; set; }

        [Required(ErrorMessage = "Please Enter Branch Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Code")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Code is 3 digts Long")]
        public string Code { get; set; }
        public string Description { get; set; }

        public List<Category> Categories { get; set; }
        public List<SelectListItem> GeneralCategories { get; set; }
    }
}