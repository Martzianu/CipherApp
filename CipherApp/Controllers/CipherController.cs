using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CipherApp.DataLayer.TableModule;
using CipherApp;
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
            partialTable.Add(table.getTable().ElementAt(table.getTable().Count-1));
            partialTable.Add(table.getTable().ElementAt(table.getTable().Count - 2));
            partialTable.Add(table.getTable().ElementAt(table.getTable().Count - 3));

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
        public ActionResult OpenCipherDoc(string cipherTitle)
        {
            var bla = cipherTitle;
            GetAllCiphers();
            Cipher cifru = new Cipher();
            foreach(var elem in table.getTable())
                if(elem.Title == cipherTitle)
                {
                   cifru = elem;
                   break;
                }

            return View(cifru);
        }
        public ActionResult OpenCipherDoc()
        {         
            return View();
        }
    }
}