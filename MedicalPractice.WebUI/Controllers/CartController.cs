﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicalPractice.Domain.Abstract;
using MedicalPractice.Domain.Entities;
using MedicalPractice.WebUI.Models;

namespace MedicalPractice.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IMedicalProductsRepository repository;

        public CartController(IMedicalProductsRepository repo)
        {
            repository = repo;
        }

        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            Medical_Products product = repository.ProductsRepository.FirstOrDefault(p => p.Medical_ProductsID == productId);
            Cart cart = GetCart();

            if(product != null)
            {
                cart.AddItem(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            Cart cart = GetCart();
            
            GetCart().RemoveItem(productId);
            
            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        // GET: Cart
        public ViewResult Index(string returnUrl)
        {
            return View("CartIndex", new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
        }
    }
}