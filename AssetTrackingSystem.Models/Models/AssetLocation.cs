using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AssetTrackingSystem.Models.Models
{
    public class AssetLocation
    {
        public AssetLocation()
        {

        }
        public AssetLocation(string name, string shortname)
        {
            this.Name = name;
            this.ShortName = shortname;
        }

        [Key]
        public int Id { get; set; }
        [Display(Name="Branch")]
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        [Display(Name="Organization")]
        public int OrganizationId { get; set; }

        [Required(ErrorMessage = "Please Enter Branch Name")]
        public string Name { get; set; }

      
        [Required(ErrorMessage="Please Enter Short Name")]
        [StringLength(10,MinimumLength=3,ErrorMessage="Minimum Length 3")]
        [Remote("IsShortNameExit","AssetLocation",ErrorMessage="Short Name is already Exits")]
        public string ShortName { get; set; }
    }
}