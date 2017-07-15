using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicalPractice.Domain.Entities;

namespace MedicalPractice.WebUI.Controllers
{
    public class VisitOrderController : Controller
    {

        public RedirectToRouteResult Order(Doctor d, string returnUrl)
        {            
            return RedirectToAction("Index", d);
        }

        public ViewResult Index(Doctor d, string returnUrl)
        {
            return View(d);
        }
    }
}