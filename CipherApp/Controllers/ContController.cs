using CipherApp.DataLayer.TableModule;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;

namespace CipherApp.Controllers
{
    public class ContController : Controller
    {

        int keyLength = 59;
        // GET: Cont
        public ActionResult Index()
        {
            //GenerateFilesForBlockCiphers();
            return View();

        }

        private void GenerateFilesForBlockCiphers(){
            var keys = MakeKey();// keya ce o vom folosi la xor-ing
            MemoryStream ms = new MemoryStream();
            Image imageIn = Image.FromFile(Constants.photoPath);
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            var imageByteArray = ms.ToArray();
            EBC(imageByteArray, keys);
            //CBC(imageByteArray, keys);
            //CFB(imageByteArray, keys);
            //OFB(imageByteArray, keys);
            //CTR(imageByteArray, keys);
        }

        private void CTR(byte[] imageByteArray, byte[] keys)
        {
            throw new NotImplementedException();
        }

        private void OFB(byte[] imageByteArray, byte[] keys)
        {
            throw new NotImplementedException();
        }

        private void CFB(byte[] imageByteArray, byte[] keys)
        {
            throw new NotImplementedException();
        }

        private void CBC(byte[] imageByteArray, byte[] keys)
        {
            byte[] newImageByteArray = new byte[28261];
            var initializeVector = MakeKey();
            byte[] newVector = new byte[59];
            int i;
            for(i = 0; i< 59; i++)
            {
                newImageByteArray[i] = (byte)(imageByteArray[i] ^ initializeVector[i] ^ keys[i]) ;
                newVector[i] = (byte)(imageByteArray[i] ^ initializeVector[i] ^ keys[i]);
            }
            ContinueCBC(newVector,imageByteArray, newImageByteArray, keys, i);
        }

        private void ContinueCBC(byte[] newVector, byte[] imageByteArray, byte[] newImageByteArray, byte[] keys, int i)
        {
            int j = 0;
            byte[] helpVector = new byte[59];
            if(i < imageByteArray.Length)
            {
                int k = i;
                for(k=i;k<k+59;k++)
                {
                    newImageByteArray[k] = (byte)(imageByteArray[k] ^ newVector[k] ^ keys[j]);
                    helpVector[k] = (byte)(imageByteArray[k] ^ newVector[k] ^ keys[j]);
                    j++;
                }
                ContinueCBC(helpVector, imageByteArray, newImageByteArray, keys, i);
            }
        }
   

        private void EBC(byte[] imageByteArray, byte[] keys)
        {
            byte[] newImageByteArray = new byte[28261];
            int j = 0;
            for(int i = 0; i< imageByteArray.Length; i++)
            {
                if (j == 59)
                    j = 0;
                newImageByteArray[i] = (byte)(imageByteArray[i] ^ keys[j]);
                j++;
            }
            System.IO.File.WriteAllBytes(Constants.ecbPath, newImageByteArray);
              
        }

        

        private byte[] MakeKey()
        {
            Random bla = new Random(3);

            byte[] key = new byte[keyLength];
            bla.NextBytes(key);
            return key;
            
        }
        //28261
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
             using (var ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length))
            {
               var returnImage = System.Drawing.Image.FromStream(ms);
                  returnImage.Save(@"C:\Users\Dragos\Desktop\bla.jpg", ImageFormat.Jpeg);
                return returnImage;
            }
               
            
        }
        [HttpPost]   
        public ActionResult Index(string _username,string _password)
        {
            User user = new User
            {
                username = _username,
                password = _password

            };
            UserHandler handler = new UserHandler();
            if (handler.LogIn(user) == true)
            {
                Constants.name = user.username;
                return RedirectToAction("All", "Cipher");
            }
            else
            {
                ViewBag.text = "Logare esuata";
                return View();
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string _username, string _password, string _email, bool? _isprof)
        {
            
            User user = new User
            {
                username = _username,
                password = _password,
                email = _email,
                isProf = _isprof
            };
          if(_username == "" || _password == "" || _email == "")
                return View();
           
            UserHandler handler = new UserHandler();

            if (handler.RegisterUser(user) == true)
            {
                Constants.name = user.username;
                return RedirectToAction("All", "Cipher");
            }
            else
            {
                ViewBag.text = "Inregistrare esuata";
                return View();
            }
        }

        public ActionResult Settings()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Settings(string action, string currentPass, string currentMail, string retypePass, string retypeMail)
        {
            // ori modificare email
            // ori modificare password
            // ori logout
 
            if (action == "Logout")
            {
                Constants.name = null;
                Constants.isProfLogged = null; 
                return RedirectToAction("Index", "Cont");
            }
            if(action == "ChangeMail")
            {
                if (currentMail != Constants.mail)
                {
                    ViewBag.text = "Adresele de mail nu se potrivesc sau nu ati introdus mailul actual";
                    return View();
                }
                else
                {
                    UserHandler handler = new UserHandler();
                    ViewBag.text = "Succes!";
                    handler.Update(retypeMail, "email");
                }
            }
            if (action == "ChangePass")
            {
                if (currentPass != Constants.pass)
                {
                    ViewBag.text = "Parolele nu se potrivesc sau nu ati introdus parola actuala";
                    return View();
                }
                {
                    UserHandler handler = new UserHandler();
                    ViewBag.text = "Succes!";
                    handler.Update(retypePass, "password");
                }
            }
            return View();
        }
        
    }
}