using CipherApp.DataLayer.TableModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CipherApp.Controllers
{
    public class ExerciseController : Controller
    {
        // GET: Exercise
        public ActionResult AddExercise()
        {
            CipherHandler handler = new CipherHandler();
            CipherTable table = new CipherTable();
            table = handler.getCiphers();
            List<string> ciphernameList = new List<string>();
            foreach(var item in table.getTable())
            {
                ciphernameList.Add(item.Title);
            }
            return View(ciphernameList);
        }
    }
}