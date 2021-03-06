﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Domain.Abstract;
using Store.Domain.Entities;
using Store.WebUI.Models;

namespace Store.WebUI.Controllers
{
    public class ProductController : Controller
    {

        private IProductRepository repository;
        public int pageSize = 4;
        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }
        public ViewResult List(string category ,int page=1)
        {
            //return View(repository.Products.OrderBy(p=>p.ProductID)
            //                               .Skip((page-1)*pageSize)
            //                               .Take(pageSize));
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products.Where(p => category == null || p.Category == category)
                                            .OrderBy(p => p.ProductID)
                                            .Skip((page - 1) * pageSize)
                                            .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category==null?
                        repository.Products.Count():
                        repository.Products.Where(e=>e.Category==category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}