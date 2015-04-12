using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CipherApp.DataLayer.TableModule;
using CipherApp.StringSorting;
namespace CipherApp.Controllers
{
    public class CipherController : Controller
    {
        public CipherTable table = new CipherTable();
        CipherHandler handler = new CipherHandler();

        public ActionResult All()
        {
            List<Cipher> partialTable = new List<Cipher>();
            GetAllCiphers();
            partialTable.Add(table.getTable().ElementAt(0));
            partialTable.Add(table.getTable().ElementAt(1));
            partialTable.Add(table.getTable().ElementAt(2));

            return View(partialTable);
            
        }

        public ActionResult PerCathegories()
        {
            GetAllCiphers();
            return View(table.getTable().ToList());
        }

        private void GetAllCiphers()
        {
            this.table = handler.getCiphers();
        
        }

        [HttpPost]
        public ActionResult OpenCipherDoc(Cipher cipherTitle)
        {
            var bla = cipherTitle;
            //Cipher cifru = new Cipher();
            //foreach(var elem in table.getTable())
             //   if(elem.Title == cipherTitle)
             //   {
           //        cifru = elem;
            //    }

            return View(cipherTitle);
        }
        public ActionResult OpenCipherDoc()
        {
            string text = "AHLQFJDBGKSBSKJHGHALKJBLKLASDLGJSLKJJFJEPEPRGNNSKS";
            SortString sort = new SortString();
            for (int i = 0; i < text.Length; i++)
            {
                sort.addLetter(text[i].ToString());
            }
            var bla = sort.getDictionary();
            ListsForFrontEnd lists = new ListsForFrontEnd();
            lists.Keys = bla.Keys.ToList();
            lists.Values = bla.Values.ToList();
            return View(lists);
        }
    }
}