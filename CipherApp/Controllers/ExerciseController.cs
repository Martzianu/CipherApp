using CipherApp.DataLayer.TableModule;
using CipherApp;
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
            
            Sabloane sab = new Sabloane(2, "AABBCCDDEEFFFAAAAAACCAAEEAABB");
            return View(MakeTitleList());
        }

        private List<string> MakeTitleList()
        {
            CipherHandler handler = new CipherHandler();
            CipherTable table = new CipherTable();
            table = handler.getCiphers();
            List<string> ciphernameList = new List<string>();
            foreach (var item in table.getTable())
            {
                ciphernameList.Add(item.Title);
            }
            return ciphernameList;
        }
        [HttpPost]
        public ActionResult AddExercise(string cipher,string cerinta,string detalii, bool privat,string text,bool obligatoriu)
        {
            Exercise ex = new Exercise();
            ExerciseHandler handler = new ExerciseHandler();
            ex.Cifru = cipher;
            ex.Detalii = detalii;
            ex.Enunt = cerinta;
            ex.Privat = privat;
            ex.TextNormal = text;
            ex.Obligatoriu = obligatoriu;
            handler.AddExercise(ex);

            return View(MakeTitleList());
        }

        public ActionResult ExercisesPage(string cipher)
        {
            var blaa = cipher;
            List<Exercise> ExList = new List<Exercise>();
            ExerciseHandler handler = new ExerciseHandler();
            if(cipher == null)
            ExList = handler.GetMandatoryExercices(true);
            else ExList = handler.GetExercicesForCipher(cipher);
            return View(ExList);
        }
        [HttpPost]
        public ActionResult ShowSubstring(string text, int number)
        {
            Sabloane sabloane = new Sabloane(number,text);
            var sabloaneList = sabloane.GetSabloane();
           // foreach (var elem in bla)
            return View(sabloaneList);
        }
        [HttpPost]
        public ActionResult ShowChart(string text)
        {
            text = text.ToUpper();
            SortString sort = new SortString(text);
            for (int i = 0; i < text.Length; i++)
            {
                sort.addLetter(text[i]);
            }
            var bla = sort.getDictionary();
            ListsForFrontEnd lists = new ListsForFrontEnd();
            lists.Keys = bla.Keys.ToList();
            lists.Values = bla.Values.ToList();
           
            return View(lists);
        }
        public ActionResult Download()
        {
            return View();
        }

       
    }
}