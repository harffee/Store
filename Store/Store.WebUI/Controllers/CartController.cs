﻿using Store.Domain.Abstract;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.WebUI.Models;

namespace Store.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        //private IOrderProcessor orderProcessor;

        public CartController(IProductRepository repo)
        {
            repository = repo;
            //orderProcessor = proc;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        //public PartialViewResult Summary(Cart cart)
        //{
        //    return PartialView(cart);
        //}

        //[HttpPost]
        //public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        //{
        //    if (cart.Lines.Count() == 0)
        //    {
        //        ModelState.AddModelError("", "Sorry, your cart is empty!");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        orderProcessor.ProcessOrder(cart, shippingDetails);
        //        cart.Clear();
        //        return View("Completed");
        //    }
        //    else
        //    {
        //        return View(shippingDetails);
        //    }
        //}

        //public ViewResult Checkout()
        //{
        //    return View(new ShippingDetails());
        //}

        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                GetCart().RemoveLine(product);
            }
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
    }
}