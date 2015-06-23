using CipherApp.DataLayer.TableModule;
using CipherApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Xml;

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
        public ActionResult AddExercise(string cipher, string cerinta, string detalii, bool privat, string text,string raspuns, bool obligatoriu, bool profPrivat)
        {

            Exercise ex = new Exercise();
            ExerciseHandler handler = new ExerciseHandler();
            ex.Cifru = cipher;
            ex.Detalii = detalii;
            ex.Enunt = cerinta;
            ex.Privat = privat;
            ex.TextNormal = text;
            ex.TextCriptat = raspuns;
            ex.Obligatoriu = obligatoriu;
            if (profPrivat == true)
                ex.Prof = Constants.name;
            else ex.Prof = "";
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
            List<Exercise> ExList = new List<Exercise>();
            ExerciseHandler handler = new ExerciseHandler();
            ExList = handler.GetExerciseToDownload();
            return View(ExList);
        }

        [HttpPost]
        public ActionResult Save(string cifru, string cerinta, string detalii, string text, string raspuns)
        {
            Exercise ex = new Exercise();
            ex.Cifru = cifru;
            ex.Enunt = cerinta;
            ex.Detalii = detalii;
            ex.TextNormal = text;
            ex.TextCriptat = raspuns;
            Constants.exercitiiSel.Add(ex);
            return RedirectToAction("Download", "Exercise");
        }

        [HttpPost]
        public ActionResult Download(string bla)
        {
            XmlDocument doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);
            XmlElement exercitii = doc.CreateElement(string.Empty, "Exercitii", string.Empty);
            doc.AppendChild(exercitii);
            foreach(var item in Constants.exercitiiSel)
            {

                XmlElement Cifru = doc.CreateElement(string.Empty, "Cifru", string.Empty);
                XmlText cifruText = doc.CreateTextNode(item.Cifru);
                Cifru.AppendChild(cifruText);
                exercitii.AppendChild(Cifru);

                XmlElement Enunt = doc.CreateElement("Enunt");
                XmlText enuntText = doc.CreateTextNode(item.Enunt);
                Enunt.AppendChild(enuntText);
                exercitii.AppendChild(Enunt);

                XmlElement Cerinta = doc.CreateElement("Text");
                XmlText cerintaText = doc.CreateTextNode(item.TextNormal);
                Cerinta.AppendChild(cerintaText);
                exercitii.AppendChild(Cerinta);

                XmlElement Raspuns = doc.CreateElement("Raspuns");
                XmlText raspunstText = doc.CreateTextNode(item.TextCriptat);
                Raspuns.AppendChild(raspunstText);
                exercitii.AppendChild(Raspuns);

            }
            doc.Save("D:\\document.xml");
            List<Exercise> ExList = new List<Exercise>();
            ExerciseHandler handler = new ExerciseHandler();
            ExList = handler.GetExerciseToDownload();
            return View(ExList);
        }

       
    }
}