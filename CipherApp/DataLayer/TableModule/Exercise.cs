using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CipherApp.DataLayer.TableModule
{
    public class Exercise
    {
        public string Cifru { get; set; }
        public string Enunt { get; set; }
        public bool Privat { get; set; }
        public string Detalii { get; set; }
        public string TextNormal{ get; set; }
        public string TextCriptat { get; set; }
        public bool Obligatoriu { get; set; }
        public string Prof { get; set; }
    }
}