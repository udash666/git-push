using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AssetTrackingSystem.Models.Models
{
   
    public class GeneralCategory
    {
        public GeneralCategory()
        {

        }
        public GeneralCategory(string name, string code)
        {
            this.Name = name;
            this.Code = code;
        }

        [Key]
        public int Id { get; set; }

         
        [StringLength(450)]
        [Required(ErrorMessage="Enter Name")]
        [Remote("IsNameExit", "GeneralCategory", ErrorMessage="Name is already exits")]
        public string Name { get; set; }
  
        [StringLength(2,MinimumLength=2,ErrorMessage="Code is 2 didgits Long")]
        [Remote("IsCodeExit", "GeneralCategory", ErrorMessage = "Code is already exits")]
        [Required(ErrorMessage="Enter Code")]
        public string Code { get; set; }
    }
}