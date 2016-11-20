using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AssetTrackingSystem.Models.Models;
using AssetTrackingSystem.Models.Models.ViewModel;
using Asset_Tracking_System.Models.ViewModel;
using Asset_Tracking_System.Models;

namespace Asset_Tracking_System
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Mapper.Initialize(configuration =>
            {

                configuration.CreateMap<GeneralCategoryCreateVM, GeneralCategory>();
                configuration.CreateMap<CategoryCreateVM, Category>();
                configuration.CreateMap<SubCategoryCreateVM, SubCategory>();
                configuration.CreateMap<AssetLocationVM, AssetLocation>();
                configuration.CreateMap<DetailsCategoryCreateVM, DetailsCategory>();
                configuration.CreateMap<DetailsCategoryEditVM, DetailsCategory>();
                configuration.CreateMap<AssetEntryCreateVM, AssetEntry>();
            }

           );
        }
    }
}
