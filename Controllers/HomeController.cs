using System;
using CourseApp.Models;
using dotnet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace CourseApp.Controllers
{
    // localhost:5000
    // localhost:5000/home  
    public class HomeController : Controller
    {
        // localhost:5000/home/index => home/index.cshtml 
        public IActionResult Index()
        {
            int saat = DateTime.Now.Hour;

            ViewBag.Greeting = saat > 12 ? "İyi günler" : "Günaydın";
            ViewBag.UserName = "Nilgün";

            return View();
        }

        // localhost:5000/home/about => home/about.cshtml
        public IActionResult About()
        {
           var categories = new List<Category>()
            {
                new Category(){ Name="Kategori 1"},
                new Category(){ Name="Kategori 2"},
                new Category(){ Name="Kategori 3"}
            };
            var products = new List<Product>()
            {
                new Product(){ Name="Product 1"},
                new Product(){ Name="Product 2"},
                new Product(){ Name="Product 3"}
            };

            var model = new ProductsCategoriesViewModel();

            model.Products = products;
            model.Categories = categories;


            return View(model);
        }
    }
}