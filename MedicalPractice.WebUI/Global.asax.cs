﻿using MedicalPractice.Domain.Concrete;
using MedicalPractice.Domain.Entities;
using SportsStore.WebUI.Infrastructure.Binders;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MedicalPractice.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer<EFDbContext>(null);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
