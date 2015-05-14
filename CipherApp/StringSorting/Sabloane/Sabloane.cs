using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CipherApp
{
    public class Sabloane
    {
        // gaseste subtexte de n(n specificat  ca parametru) dimensiuni ale textului dat
        // si zice indexul de aparitie celor top 3 care apar cel mai des

         AparitieSubstring max1 = new AparitieSubstring(); // cel mai des
         AparitieSubstring max2 = new AparitieSubstring(); // mai putin des
         AparitieSubstring max3 = new AparitieSubstring(); // si mai putin des
      
        int substringLength;
         string text;
         string currentString;
         int currentStartingIndex = 0; // se incrementeaza cand vreau un nou substring
        
        public Sabloane(int _substringLength, string _text)
        {
            substringLength = _substringLength;
            text = _text;
            GetSabloane();
        }

        public List<AparitieSubstring> GetSabloane()
        {
            List<AparitieSubstring> lista = new List<AparitieSubstring>();
            for(int currentStartingIndex=0;currentStartingIndex<text.Length - substringLength + 1;currentStartingIndex++)
            {
                AparitieSubstring maxTest = new AparitieSubstring(); // de testat
                currentString = text.Substring(currentStartingIndex, substringLength);
                if (currentString == max1.text || currentString == max2.text || currentString == max3.text)
                    continue;
                maxTest.text = currentString;
                maxTest.aparitii = 1;
                maxTest.indexuri.Add(currentStartingIndex);
                int poz = currentStartingIndex;
                while(poz < text.Length && poz >=0)
                {
                    poz = text.IndexOf(currentString, poz + 1);
                    if (poz >= 0)
                    {
                        maxTest.indexuri.Add(poz);
                        maxTest.aparitii++;
                    }
                    // dupa ce iesim de aici avem aparitiile si cate
                }
                //vedem daca avem noi substringuri pe podium
                if (maxTest.aparitii >= max1.aparitii)
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = maxTest;                   
                }
                else
                {
                    if(maxTest.aparitii >= max2.aparitii)
                    {
                        max3 = max2;
                        max2 = maxTest;
                    }
                    else
                        if(maxTest.aparitii >= max3.aparitii)
                        {
                            max3 = maxTest;
                        }
                }
            }
            lista.Add(max1);
            lista.Add(max2);
            lista.Add(max3);
            return lista;
        }


    }
}