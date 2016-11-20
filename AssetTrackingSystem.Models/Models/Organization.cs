using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace AssetTrackingSystem.Models.Models
{
    public class Organization
    {
        public Organization()
        {

        }

        public Organization(string name, string code, string location)
        {
            this.Name = name;
            this.Code = code;
            this.Location = location;
        }
        [Key]
        public int Id { get; set; }

        [Display(Name= "Organization Name")]
        [Required(ErrorMessage = "Please Enter Organization Name")]
        [Remote("IsNameExit", "Organization", ErrorMessage= "Name Already Exits")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Organization Short Name")]
        [Remote("IsShortNameExit", "Organization", ErrorMessage = "Short Name Already Exits")]
        [Display(Name = "Short Name")]
        [StringLength(450)]
        public string ShortName { get; set; }

  
        
        [Required(ErrorMessage = "Please Enter Code")]
        [StringLength(3,MinimumLength=3,ErrorMessage= "Code is 3 digits long")]
        [Remote("IsCodeExit", "Organization", ErrorMessage = "Code Already Exits")]
        public string Code { get; set; }

        public string Location { get; set; }
    }
     
}
