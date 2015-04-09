using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CipherApp.DataLayer.TableModule
{
    public class CipherTable
    {
        // fiecare inregistrare este un cifru
        private List<Cipher> cipherTable = new List<Cipher>();

        public void Add(Cipher cipher)
        {
            cipherTable.Add(cipher);
        }
        public List<Cipher> getTable()
        {
            return cipherTable;
        }
    }
}