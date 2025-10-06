using Microsoft.AspNetCore.Mvc;
using test.Data;
using test.Models;

namespace test.Controllers
{
    public class restController : Controller
    {
        private readonly ApplicationDbContext _ponnapan;
        public restController(ApplicationDbContext soman)
        {
            _ponnapan = soman;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var ma = _ponnapan.resturent.ToList();

            return View(ma);

        }

        [HttpGet]
       public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(retu tb )
            
        {
            if(ModelState != null)
            {
                _ponnapan.resturent.Add(tb);
                _ponnapan.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public IActionResult edit(int id)
        {
            var s = _ponnapan.resturent.Find(id);
            return View(s);
        }


        [HttpPost]
        public IActionResult edit(retu soo)

        {
          if(ModelState!= null)
            {
                _ponnapan.resturent.Update(soo);
                _ponnapan.SaveChanges();
                return RedirectToAction("Index");
            }
        
            return View();
        }


        public IActionResult delete(int id)
        {
            var x = _ponnapan.resturent.Find(id);
            if(x!=null)
            {
                _ponnapan.resturent.Remove(x);
                _ponnapan.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }


    }
}
