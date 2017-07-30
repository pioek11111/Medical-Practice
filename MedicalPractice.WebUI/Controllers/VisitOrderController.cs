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
        public RedirectToRouteResult Order(string d, string returnUrl)
        {            
            return RedirectToAction("Index", d);
        }

        public ViewResult Index(string name, string surname, int id, string returnUrl)
        {
            return View(new Model1 { Name = name, Surname  = surname, Id = id});
        }
    }

    public class Model1
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Id { get; set; }
    }
}