﻿using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Product
        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }

        public string Add()
        {
            _productService.Add(new Product
            {
                CategoryId = 1,
                ProductName = "A. Gsm",
                QuantityPerUnit = "1",
                UnitPrice = 23
            });
            return "Added.";
        }

        public string AddUpdate()
        {
            _productService.TransactionalOperation(
                new Product
                {
                    CategoryId = 1,
                    ProductName = "A. Telefon",
                    QuantityPerUnit = "3",
                    UnitPrice = 12
                },
                new Product
                {
                    ProductId = 80,
                    CategoryId = 3,
                    ProductName = "A. update",
                    QuantityPerUnit = "22",
                    UnitPrice = 44
                });
            return "Transaction method runned.";
        }
    }
}