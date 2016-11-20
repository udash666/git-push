using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AssetTrackingSystem.Models.Models.ViewModel
{
    public class AssetLocationVM
    {

        
        public int Id { get; set; }

        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        [Display(Name = "Organization")]
        public int OrganizationId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage="Short Name is Required")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Minimum Length 3")]
        [Remote("IsShortNameExit", "AssetLocation", ErrorMessage = "Short Name is already Exits")]
        public string ShortName { get; set; }

        public List<SelectListItem> Organizations { get; set; }
        public List<SelectListItem> Branches { get; set; }
    }
}