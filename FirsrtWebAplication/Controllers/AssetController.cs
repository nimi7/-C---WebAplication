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
    public class AssetController : Controller
    {
        // GET: Asset
        public List<Asset> DB()
        {
            BLL b = new BLL();

            List<Asset> ass = b.SearchAllAsset(); 

            return ass;
        }
        public ActionResult Create()
        {
            BLL b = new BLL();
            List<Landlord> landlords = b.SearchAllLandlord();
            ViewBag.LandList = b.LandlordList(landlords);
            List<City> cities = b.SesrchAllCity();
            ViewBag.Citylist = b.CityList(cities);
            return View();
        }
        public ActionResult Index(string Search)
        {

           List<Asset> assets = DB();
            if (!string.IsNullOrEmpty(Search))
            {
                assets = assets.Where(x => x.Street.ToLower().Contains(Search.ToLower())).ToList();
            }
            return View(assets);

        }

        [HttpPost]
        public ActionResult Create(Asset asset)
        {
            BLL b = new BLL();
           
            if (ModelState.IsValid)
            {
                b.CreatAsset(asset);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            List<Asset> assets= DB();
            Asset t = assets.Where(x => x.AssetID == id).FirstOrDefault();
            if (t != null)
            {
                return View(t);
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(Asset c)
        {
            BLL l = new BLL();
            if (ModelState.IsValid)
            {
                l.AssetUpDate(c);
                return RedirectToAction("Index");
            }
            return View(c);
        }
        public ActionResult Details(int id)
        {
            List<Asset> asset = DB();
            Asset ass = new Asset();
            ass = asset.Where(x => x.AssetID.Equals(id)).FirstOrDefault();
            return View(ass);

        }

        //public SelectList CityList(List<City> cities)
        //{
        //    List<SelectListItem> list = new List<SelectListItem>();
        //    foreach (City city in cities)
        //    {
        //        list.Add(new SelectListItem()
        //        {
        //            Text = city.CityName,
        //            Value = city.Cityid.ToString()
        //        });
        //    }
        //    return new SelectList(list, "Value", "Text");


        //}
    }
}