using FirsrtWebAplication.Helps;
using FirsrtWebAplication.Models;
using Microsoft.VisualStudio.Services.DelegatedAuthorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirsrtWebAplication.Controllers
{
   

    public class UsersController : Controller
    {
        // GET: User

        [MySucurityFilter]
        [AutorizeFilter]
        public ActionResult SeeUser()
        {
            BLL l = new BLL();
            List<Users> users = l.SesrchAllUsers();

            return View(users);
        } 
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        
        public ActionResult Login(Users user)
        {
            BLL l = new BLL();
            List<Users> users = l.SesrchAllUsers();
            Users loginuser = users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
            if (loginuser != null)
            {
                Session["RoleName"] = loginuser.RoleName;
                Session["FullName"] = loginuser.FullName;
               // return RedirectToAction("SeeUser");
            }
          
            return RedirectToAction("Index", "Landlord");


        }
        
        public ActionResult Logout()
        {
            Session["FullName"] = null;
            return RedirectToAction("Index", "Landlord");
        }
        [AutorizeFilter]
        public ActionResult Create()
        {
            BLL b = new BLL();
            List<Roles> roles = b.SesrchAllRoles();
            ViewBag.Roles = b.RolesList(roles);
            // ViewBag.Roles = b.SesrchAllRoles();
           
            return View();
        }

        [HttpPost]
        public ActionResult Create(Users users)
        {
            BLL l = new BLL();

            if (ModelState.IsValid)
            {
                l.CreatUser(users);
                return RedirectToAction("SeeUser");
            }
            
            return View();
        }
  
    }
}