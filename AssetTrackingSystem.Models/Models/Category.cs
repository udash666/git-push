using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AssetTrackingSystem.Models.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="General Category")]
        public int GeneralCategoryId { get; set; }

        public virtual GeneralCategory GeneralCategory { get; set; }

        [Remote("IsNameExit", "GeneralCategory" ,ErrorMessage="Name alreay exits")]
        [Required(ErrorMessage="Please Enter Branch Name")]
        public string Name { get; set; }

        
        [Required(ErrorMessage="Please Enter Code")]
        [StringLength(10,MinimumLength =3, ErrorMessage= "Code is 3 digts Long")]
        [Remote("IsCodeExit","GeneralCategory", ErrorMessage="Code already exits")]
        public string Code { get; set; }

        public string Description { get; set; }
    }
}