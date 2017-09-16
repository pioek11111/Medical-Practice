using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicalPractice.Domain.Abstract;
using MedicalPractice.Domain.Entities;
using MedicalPractice.WebUI.Models;
using SportsStore.Domain.Abstract;

namespace MedicalPractice.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IMedicalProductsRepository repository;
        private IOrderProcessor orderProcessor;

        public CartController(IMedicalProductsRepository repo, IOrderProcessor order)
        {
            repository = repo;
            orderProcessor = order;
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Medical_Products product = repository.ProductsRepository.FirstOrDefault(p => p.Medical_ProductsID == productId);
            
            if(product != null)
            {
                cart.AddItem(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {                       
            cart.RemoveItem(productId);
            
            return RedirectToAction("Index", new { returnUrl });
        }

        //private Cart GetCart()
        //{
        //    Cart cart = (Cart)Session["Cart"];
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}

        // GET: Cart
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View("CartIndex", new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }

        public ViewResult Checkout()
        {
            return View(new VisitDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, VisitDetails shippingDetails)
        {
            if (cart.List.Count() == 0)
            {
                ModelState.AddModelError("", "Koszyk jest pusty!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }

            else
            {
                return View(shippingDetails);
            }
        }
    }
}