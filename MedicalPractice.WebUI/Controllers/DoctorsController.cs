using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicalPractice.Domain.Abstract;
using MedicalPractice.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{
    public class DoctorsController : Controller
    {
        private IDoctorsRepository repository;
        public DoctorsController(IDoctorsRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List()
        {
            return View("List2", repository.repository);
        }
    }
}