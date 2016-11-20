using System.ComponentModel.DataAnnotations;

namespace AssetTrackingSystem.Models.Models
{
  
    public class DetailsCategory
    {
        public DetailsCategory()
        {

        }
        public DetailsCategory(string detailscategory, string code)
        {
            this.detailsCategory = detailscategory;
            this.Code = code;
        }
        [Key]
        public int Id { get; set; }
        [Display(Name="General Category")]
        public int GeneralCategoryId { get; set; }
        [Display(Name="Category")]
        public int CategoryId { get; set; }
        [Display(Name="Sub Category")]
        public int SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        [Required]
        [Display(Name="Product Category/Model")]
        public string detailsCategory { get; set; }
        [Required]
        [StringLength(10,MinimumLength=3,ErrorMessage="Code is 3 digits long")]
        public string Code { get; set; }
        public string Description { get; set; }
    }
}