using Microsoft.AspNetCore.Mvc;
using test.Data;
using test.Models;

namespace test.Controllers
{
    public class collegeController : Controller
    {
        private readonly ApplicationDbContext _college;  
        public collegeController(ApplicationDbContext app)
        {
            _college = app;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var a = _college.colleges.ToList();
            return View(a);
        }


        [HttpGet]
        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(college ab)
        {
            if(ModelState!=null)
            {
                _college.colleges.Add(ab);
                _college.SaveChanges();
            }
            return View();
        }


        [HttpGet]
        public IActionResult edit()
        {
            return View();
        }


        [HttpPost]
        public IActionResult edit(college wo)

        {
            if(ModelState!=null)
            {

                _college.colleges.Update(wo);
                _college.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
                
        }


        public IActionResult delete(int id)
        {
            var del = _college.colleges.Find(id);
            if(ModelState!=null)
            {
                _college.colleges.Remove(del);
                _college.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
    }
}
