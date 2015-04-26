using CipherApp.DataLayer.TableModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CipherApp.Controllers
{
    public class ContController : Controller
    {
        // GET: Cont
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]   
        public ActionResult Index(string _username,string _password)
        {
            User user = new User
            {
                username = _username,
                password = _password

            };
            UserHandler handler = new UserHandler();
            if (handler.LogIn(user) == true)
            {
                Constants.name = user.username;
                return RedirectToAction("All", "Cipher");
            }
            else
            {
                ViewBag.text = "Logare esuata";
                return View();
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string _username, string _password, string _email, bool? _isprof)
        {
            
            User user = new User
            {
                username = _username,
                password = _password,
                email = _email,
                isProf = _isprof
            };
          if(_username == "" || _password == "" || _email == "")
                return View();
           
            UserHandler handler = new UserHandler();

            if (handler.RegisterUser(user) == true)
            {
                Constants.name = user.username;
                return RedirectToAction("All", "Cipher");
            }
            else
            {
                ViewBag.text = "Inregistrare esuata";
                return View();
            }
        }

        public ActionResult Settings()
        {
            return View();
        }
        
    }
}