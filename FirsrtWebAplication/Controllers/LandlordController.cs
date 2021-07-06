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

    public class LandlordController : Controller
    {
        // GET: Landlord
       public List<Landlord> DB()
        {
            
            BLL l = new BLL();
            List<Landlord> land = l.SearchAllLandlord();
            return land;
            //List<Landlord> land = new List<Landlord>()
            //{
            //    new Landlord(){Landlordid = 2, Firstname="Nimrod",Lastname="Wandam", Phone="053-720-5885"},
            //    new Landlord(){Landlordid = 2, Firstname="Hagai",Lastname="Kasa", Phone="053-720-5885"},
            //    new Landlord(){Landlordid = 2, Firstname="Yossef",Lastname="Tegawi", Phone="053-720-5885"},
            //    new Landlord(){Landlordid = 2, Firstname="Yossi",Lastname="Saban", Phone="053-720-5885"},
            //    new Landlord(){Landlordid = 2, Firstname="Sapir",Lastname="yayeh", Phone="053-720-5885"},
            //};
            //return land;
        }
       
        public ActionResult Index(string Search)
        {

            List<Landlord> t = DB();
            if (!string.IsNullOrEmpty(Search))
            {
                t = t.Where(x => x.Firstname.ToLower().Contains(Search.ToLower())).ToList();
            }

            
            return View(t);

        }




        public ActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Create(Landlord land)
        {
            BLL l = new BLL();
            
            if (ModelState.IsValid)
            {
                l.CreatLandlord(land);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            List<Landlord> land = DB();
            Landlord t = land.Where(x => x.Landlordid == id).FirstOrDefault();
            if (t != null)
            {
                return View(t);
            }
            return View("Index");
        }

        public ActionResult Details(int id)
        {
            List<Landlord> lord = DB();
            Landlord landlord = new Landlord();
            landlord = lord.Where(x => x.Landlordid.Equals(id)).FirstOrDefault();
            return View(landlord);

        }

        [HttpPost]
        public ActionResult Edit(Landlord land)
        {
            BLL b = new BLL();
            if (ModelState.IsValid)
            {
                b.LandlordUpDate(land);
                return RedirectToAction("Index");
            }
            return View(land);
        }
    }
}