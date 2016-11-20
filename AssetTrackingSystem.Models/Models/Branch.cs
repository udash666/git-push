using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace AssetTrackingSystem.Models.Models
{
    public class Branch
    {
        public Branch()
        {

        }
        public Branch(string name, string shortname)
        {
            this.Name = name;
            this.ShortName = shortname;
        }
        [Key]
        public int Id { get; set; }
        [Display(Name="Organization")]
        public int OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }

      
        [Required(ErrorMessage = "Please Enter Branch Name")]
        [Display(Name = "Branch Name")]
        public string Name { get; set; }

        [Remote("IsShortNameExit", "Branch", ErrorMessage = "Short Name Is already Exits")]
        [Display(Name = "Short Name")]
        [StringLength(10,MinimumLength=3,ErrorMessage="Minimumm Length is 3")]
        [Required(ErrorMessage="Please Enter Short Name")]
        public string ShortName { get; set; }
    }
}