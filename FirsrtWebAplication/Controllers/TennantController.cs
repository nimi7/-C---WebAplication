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
    public class TennantController : Controller
    {
        // GET: Tennant

        public List<Tenant> DB()
        {
            BLL l = new BLL();
            List<Tenant> ts = l.SesrchAllTenant();
            return ts;

        }
        public ActionResult Index(string Search)
        {

            List<Tenant> t = DB();
            if (!string.IsNullOrEmpty(Search))
            {
                t = t.Where(x => x.FirstName.ToLower().Contains(Search.ToLower())).ToList();
            }
            return View(t);

        }




        public ActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Create(Tenant tennant)
        {
            BLL l = new BLL();
            

            if (ModelState.IsValid)
            {
                l.CreatTenant(tennant);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            List<Tenant> tennants = DB();
            BLL B = new BLL();

            Tenant t = tennants.Where(x => x.Tenantid == id).FirstOrDefault();

            if (t != null)
            {
                return View(t);
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(Tenant t)
        {
            BLL bll = new BLL();
            if (ModelState.IsValid)
            {
                bll.TenantUpDate(t);
                return RedirectToAction("Index");
            }
            return View(t);
        }
        public ActionResult Details(int id)
        {
            List<Tenant> ten = DB();
            Tenant tennant = new Tenant();
            tennant = ten.Where(x => x.Tenantid.Equals(id)).FirstOrDefault();
            return View(tennant);

        }

        public ActionResult Delete(int id)
        {
            //List<Tenant> ten = DB();
            //Tenant tennant = new Tenant();
            //tennant = ten.Where(x => x.Tenantid.Equals(id)).FirstOrDefault();

            return View();


        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            List<Tenant> tennants = DB();
            BLL B = new BLL();

            Tenant t = tennants.Where(x => x.Tenantid == id).FirstOrDefault();

            if (t != null)
            {
                tennants.Remove(t);
                return RedirectToAction("Index");
            }
            return new HttpNotFoundResult();

        }

        //public ActionResult Index(string SearchString)
        //{
        //    List<Tenant> t = DB();
        //    if (!string.IsNullOrEmpty(SearchString))
        //    {
        //        t = t.Where(x => x.FirstName.ToLower().Contains(SearchString.ToLower())).ToList();
        //    }
        //    return View(t);
        //}
    }
}