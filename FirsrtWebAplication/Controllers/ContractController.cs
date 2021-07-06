using FirsrtWebAplication.Helps;
using FirsrtWebAplication.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FirsrtWebAplication.Controllers
{
    [MySucurityFilter]
    public class ContractController : Controller
    {
        // GET: Contract
        public List<Contract> DB()
        {
            BLL B = new BLL();
            List<Contract> con = B.SesrchAllContract();
            return con;
        }
        public ActionResult Create()
        {
            BLL b = new BLL();
            List<Tenant> tenants = b.SesrchAllTenant();
            ViewBag.tenant = b.TenantList(tenants);
            List<Landlord> landlords = b.SearchAllLandlord();
            ViewBag.LandList = b.LandlordList(landlords);
            List<Asset> ass = b.SearchAllAsset();
            ViewBag.asset = b.AssetList(ass);

            return View();
        }
        public ActionResult Index(string Search)
        {

            List<Contract> t = DB();
            if (!string.IsNullOrEmpty(Search))
            {
                t = t.Where(x => x.Contractid.ToString().Contains(Search.ToLower())).ToList();
            }
            return View(t);

        }




      

        [HttpPost]
        public ActionResult Create(Contract con)
        {
            BLL b = new BLL();
           
            if (ModelState.IsValid)
            {
                b.CreateContract(con);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            List<Contract> con = DB();
            Contract t = con.Where(x => x.Contractid== id).FirstOrDefault();
            if (t != null)
            {
                return View(t);
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(Contract con)
        {
            BLL b = new BLL();
            if (ModelState.IsValid)
            {
                b.ContractUpDate(con);
                return RedirectToAction("Index");
            }
            return View(con);
        }
        public ActionResult Details(int id)
        {
            List<Contract> lord = DB();
            Contract Con = new Contract();
            Con = lord.Where(x => x.Contractid.Equals(id)).FirstOrDefault();
            return View(Con);

        }

    }
}