using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AssetTrackingSystem.Models.Models;

namespace Asset_Tracking_System.Models
{
    public class AssetEntry
    {
        public AssetEntry()
        {

        }
        public AssetEntry(string price, string serial)
        {
            this.Price = price;
            this.Serial = serial;
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "Purchase Date")]
        [Required(ErrorMessage = "Please select Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime PurchaseDate { get; set; }
        [Display(Name = "Vendor Information")]
        public string Vendor { get; set; }

        [Display(Name="General Category")]
        public int GeneralCategoryId { get; set; }

        [Display(Name = "Category")]

        public int CategoryId { get; set; }

        [Display(Name="Sub Category")]
        public int SubCategoryId { get; set; }

        [Display(Name="Details Category")]
        public int DetailsCategoryId { get; set; }
        public virtual DetailsCategory DetaisCategory { get; set; }

        [Display(Name = "Warrenty Period")]
        public string WarrentyPeriod { get; set; }

        public string Price { get; set; }

        public int Quantity { get; set; }
        [Display(Name = "Serial Number")]
        public string Serial { get; set; }
    }
}