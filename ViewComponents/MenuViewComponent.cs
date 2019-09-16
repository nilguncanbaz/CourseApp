using Microsoft.AspNetCore.Mvc;
using CourseApp.Models;
using System.Collections.Generic;

namespace dotnet.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        public IViewComponentResult  Invoke(){//database işlemlerinin yapıldığı yer 

             var categories = new List<Category>()
            {
                new Category(){ Name="Kategori 1"},
                new Category(){ Name="Kategori 2"},
                new Category(){ Name="Kategori 3"}
            };
            return View(categories);

        }
    }
}