using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicalPractice.Domain.Abstract;

namespace MedicalPractice.WebUI.Controllers
{
    public class MedicalProductsController : Controller
    {
        private IMedicalProductsRepository repository;
        public MedicalProductsController(IMedicalProductsRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult Index()
        {
            return View("Products", repository.ProductsRepository);
        }
    }
}