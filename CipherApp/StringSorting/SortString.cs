using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CipherApp
{
    public class SortString
    {
        // dictionar cheie valoare litera plus frecventa de aparitie
        Dictionary<string, float> letterValue = new Dictionary<string, float>();
        int textLength;
        string text;

        public SortString(string text)
        {
            textLength = text.Length;
            this.text = text.ToUpper();
        }
        public int getAppearance(char letter)
        {
            int nr = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == letter)
                    nr++;
            }
            return nr;
        }

        public void addLetter(char letter)
        {
            if (!letterValue.ContainsKey(letter.ToString().ToUpper()))
            {
                int nr = getAppearance(letter);
                float freq = nr * 100 / textLength;
                if ((freq - (int)freq).ToString().Length < 3)
                    freq = freq + 0.01f;
                letterValue.Add(letter.ToString().ToUpper(), freq);
            }          
        }
   
        public Dictionary<string, float> getDictionary()
        {
            return letterValue;
        }
    }
}