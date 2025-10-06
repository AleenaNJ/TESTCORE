using Microsoft.AspNetCore.Mvc;
using test.Data;
using test.Models;

namespace test.Controllers
{
    public class locationController : Controller
    {
        private readonly ApplicationDbContext _loc;
        public locationController(ApplicationDbContext locate)
        {
            _loc = locate;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var lo = _loc.location.ToList();
            return View(lo);
        }

        [HttpGet]
        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create (LocationMaster lb)
        {
            if(ModelState!=null)
            {
                _loc.location.Add(lb);
                _loc.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public IActionResult edit(int id)
        {
            var g = _loc.location.Find(id);
            return View(g);
        }

        [HttpPost]
        public IActionResult edit(LocationMaster ed)
        {
            if(ModelState!=null)
            {
                _loc.location.Update(ed);
                _loc.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }

        public IActionResult delete(int id)
        {
            var a = _loc.location.Find(id);
            if(a!=null)
            {
                _loc.location.Remove(a);
                _loc.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
    }
}
