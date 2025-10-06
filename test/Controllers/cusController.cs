using Microsoft.AspNetCore.Mvc;
using test.Data;
using test.Models;

namespace test.Controllers
{
    public class cusController : Controller
    {
        private readonly ApplicationDbContext _Db;
        public cusController(ApplicationDbContext Db)
        {
            _Db = Db;
        }
        [HttpGet]
        public IActionResult Index()
           
        {
            var p = _Db.customers.ToList();
            return View(p);
        }
        [HttpGet]
        public IActionResult Create()
           

        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(customer cu)


        {
            if(ModelState !=null)
            {
                _Db.customers.Add(cu);
                _Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult edit
            (int id)


        {
            var n=_Db.customers.Find(id);
            return View(n);
        }

        [HttpPost]
        public IActionResult edit
            (customer snow)


        {
            var koolie = _Db.customers.Find(snow.customerid);
            if(koolie !=null)
            {
                koolie.name = snow.name;
                koolie.description = snow.description;
                koolie.status = snow.status;
                _Db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult delete(int id)
        {
            var noobie = _Db.customers.Find(id);
            if(noobie!=null)
            {
                _Db.customers.Remove(noobie);
                _Db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}
