using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CipherApp
{
    public class AparitieSubstring
    {
        public string text { get; set; }
        public List<int> indexuri = new List<int>();
        public int aparitii { get; set; }
        public List<int> getIndexuriList()
        {
            return indexuri;
        }
    }
}