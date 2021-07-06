using FirsrtWebAplication.Helps;
using FirsrtWebAplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirsrtWebAplication.Controllers
{
    [MySucurityFilter]
    public class CItyController : Controller
    {
        // GET: CIty

        public List<City> DB()
        {
            BLL b = new BLL();
            List<City> c = b.SesrchAllCity();
            return c;
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Index(string Search)
        {

            List<City> c = DB();
            if (!string.IsNullOrEmpty(Search))
            {
                c = c.Where(x => x.CityName.ToLower().Contains(Search.ToLower())).ToList();
            }
            return View(c);

        }
        public ActionResult Details(int id)
        {
            List<City> C = DB();
            City city = new City();
            city = C.Where(x => x.Cityid.Equals(id)).FirstOrDefault();
            return View(city);

        }






        [HttpPost]
        public ActionResult Create(City c)
        {
            BLL B = new BLL();
            
            if (ModelState.IsValid)
            {
                B.CreatCity(c);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            
            List<City> land = DB();
            City t = land.Where(x => x.Cityid == id).FirstOrDefault();
            if (t != null)
            {
              
                return View(t);

            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(City t)
        {
            BLL bll = new BLL();
            if (ModelState.IsValid)
            {
                bll.CityUpDate(t);
                return RedirectToAction("Index");
            }
            return View(t);
        }
    }

}
