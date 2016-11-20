using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AssetTrackingSystem.Models.Models
{
    public class SubCategory
    {
        public SubCategory()
        {

        }
        public SubCategory(string subcategory, string code)
        {
            this.subCategory = subcategory;
            this.Code = code;
        }
        public int Id { get; set; }

        [Display(Name="General Category")]
        public  int GeneralCategoryId { get; set; }

        [Display(Name="Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required(ErrorMessage="Please Enter Name")]
        [Remote("IsNameExit","SubCategory",ErrorMessage="Name already exits")]
        [Display(Name = "Sub Category/Brand")]
        public string subCategory { get; set; }

        [Required(ErrorMessage="Please Enre Code")]
        [StringLength(10,MinimumLength=3,ErrorMessage="Code is 3 digits long")]
        [Remote("IsCodeExit","SubCategory",ErrorMessage="Code already exits")]
        public string Code { get; set; }

        public string Description { get; set; }      
    }
}