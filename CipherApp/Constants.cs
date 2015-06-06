using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CipherApp
{
    public static class Constants
    {
        public static string name = "";
        public static bool? isProfLogged = null;
        public static int studentScore;
        public static bool thereIsHomework = true;
        public static string mail = "";
        public static string pass = "";
        public static string photoPath = @"C:\Users\Dragos\Desktop\pinguin.jpg";
        public static string ecbPath = @"C:\Users\Dragos\Desktop\ecb.txt";
        public static string cbcPath = @"C:\Users\Dragos\Desktop\cbc.txt";
        public static string cfbPath = @"C:\Users\Dragos\Desktop\cfb.txt";
        public static string ofbPath = @"C:\Users\Dragos\Desktop\ofb.txt";
        public static string ctrPath = @"C:\Users\Dragos\Desktop\ctr.txt";

        public static List<CipherApp.DataLayer.TableModule.Exercise> exercitiiSel = new List<DataLayer.TableModule.Exercise>();
    }
}