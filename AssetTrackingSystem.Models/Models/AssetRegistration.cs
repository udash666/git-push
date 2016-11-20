using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssetTrackingSystem.Models.Models;
using Asset_Tracking_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Asset_Tracking_System.Models
{
    public class AssetRegistration
    {
        public int Id { get; set; }

        public int AssetId { get; set; }

        public virtual AssetEntry AssetEntry{ get; set; }

        public int LocationId { get; set; }

        public virtual AssetLocation AssetLocation { get; set; }

        [Required]
        public DateTime Date { get; set; }
         
        [Required]
        [Display(Name="Registration By")]
        public string RegistrationBy { get; set; }

        [Required]
        [Display(Name="Serial Number")]
        public string Serial { get; set; }
    }
}