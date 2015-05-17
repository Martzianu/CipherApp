using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CipherApp
{
    public class ListsForFrontEnd
    {
        public List<string> Keys { get; set; }
        public List<float> Values { get; set; }

        public List<char> Alphabet {get;set;}
        public List<float> AlphabetFrequency { get; set; }

        public ListsForFrontEnd()
        {
            Alphabet = new List<char>();
            for (char c = 'A'; c <= 'Z'; ++c)
            {
                Alphabet.Add(c);
            }
            AlphabetFrequency = new List<float>();
            AlphabetFrequency.Add(8.16f);//a
            AlphabetFrequency.Add(1.42f);//b
            AlphabetFrequency.Add(2.78f);//c
            AlphabetFrequency.Add(4.25f);//d
            AlphabetFrequency.Add(12.702f);//e
            AlphabetFrequency.Add(2.22f);//f
            AlphabetFrequency.Add(2.01f);//g
            AlphabetFrequency.Add(6.09f);//h
            AlphabetFrequency.Add(6.96f);//i
            AlphabetFrequency.Add(0.15f);//j
            AlphabetFrequency.Add(0.77f);//k
            AlphabetFrequency.Add(4.02f);//l
            AlphabetFrequency.Add(2.41f);//m
            AlphabetFrequency.Add(6.74f);//n
            AlphabetFrequency.Add(7.51f);//o
            AlphabetFrequency.Add(1.92f);//p
            AlphabetFrequency.Add(0.09f);//q
            AlphabetFrequency.Add(5.98f);//r
            AlphabetFrequency.Add(6.32f);//s
            AlphabetFrequency.Add(9.05f);//t
            AlphabetFrequency.Add(2.75f);//u
            AlphabetFrequency.Add(0.97f);//v
            AlphabetFrequency.Add(2.36f);//w
            AlphabetFrequency.Add(0.15f);//x
            AlphabetFrequency.Add(1.97f);//y
            AlphabetFrequency.Add(0.07f);//z


        }
    }
}