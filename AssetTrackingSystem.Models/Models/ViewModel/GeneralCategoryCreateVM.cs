using System.Collections.Generic;

namespace AssetTrackingSystem.Models.Models.ViewModel
{
    public class GeneralCategoryCreateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<GeneralCategory> generalCategories { get; set; }
    }
}