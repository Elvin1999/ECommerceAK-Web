using ECommerce.WebUI.ExtentionMethods;
using ECommerce.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
    public class SessionController : Controller
    {
        private IHttpContextAccessor _httpContextAccessor;

        public SessionController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            //var age = _httpContextAccessor.HttpContext.Session.GetInt32("age");
            //var name = _httpContextAccessor.HttpContext.Session.GetString("name");
            //return Ok(age+"  "+name);
            var student = _httpContextAccessor.HttpContext.Session.GetObject<StudentTest>("student");
            return Json(student);
        }
        public string Set()
        {
            _httpContextAccessor.HttpContext.Session.SetInt32("age", 24);
            _httpContextAccessor.HttpContext.Session.SetString("name", "Elvin");

            var student = new StudentTest
            {
                Id = 111,
                Name = "John",
                Surname = "Mammadov",
                Age = 55
            };

            _httpContextAccessor.HttpContext.Session.SetObject("student", student);

            return "Data set to session successfully";
        }
    }
}
