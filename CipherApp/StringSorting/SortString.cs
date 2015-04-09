using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CipherApp.StringSorting
{
    public class SortString
    {
        Dictionary<string, int> letterValue = new Dictionary<string, int>();
        
        public void addLetter(string letter)
        {
            if (!letterValue.ContainsKey(letter))
                letterValue.Add(letter, 1);
            else 
            { 
                int value = letterValue[letter];
                letterValue.Remove(letter);
                letterValue.Add(letter, value + 1);

            }
        }

        public Dictionary<string,int> getDictionary()
        {
            return letterValue;
        }
    }
}