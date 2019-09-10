using System.Linq;
using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{

    // localhost:5000/course
    public class CourseController : Controller
    {
         // action method
        // localhost:5000/course/index => course/index.cshtml
        public IActionResult Index()
        {
            var kurs=new Course(){ Id=1, Name="Kurs1"};
            ViewData["course"]=kurs;
            ViewBag.course=kurs;
            ViewBag.count=10;
            return View(kurs);
        }

        public ActionResult ByReleased(int year, int month){
            return Content("year: "+year+" month: "+ month);
        }
       
        // localhost:5000/course/apply
        [HttpGet]
        public IActionResult Apply()
        {
            return View();
        }

        // localhost:5000/course/apply method:POST
        // Name=value&Email=value&Phone=value&Confirm=value
        [HttpPost]
        public IActionResult Apply(Student student)
        {
            // Model Binding
            if(ModelState.IsValid){
                 Repository.AddStudent(student);//student model içerisinde tanımlanan 
                return View("Thanks", student);//değişkenlerin tutulduğu bir class 
       
            }
            else
            {
                return View(student);
            }
        }

        public IActionResult Details(int courseid, string sortby)
        {
           return Content("id = " + courseid + " sort by : " + sortby);
        }

        public IActionResult CourseList(int? pageindex, string sortby)
        {
            if(!pageindex.HasValue)
                pageindex=1;

            if (string.IsNullOrWhiteSpace(sortby))
                sortby="name";
                return Content("pageindex = " + pageindex + " sort by : " + sortby);
            
        }

        // localhost:5000/course/list => course/list.cshtml
        public IActionResult List()
        {
            var students = Repository.Students.Where(i => i.Confirm == true);
            return View(students);
        }
    }
}