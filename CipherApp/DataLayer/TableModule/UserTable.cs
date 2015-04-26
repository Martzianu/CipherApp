using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CipherApp.DataLayer.TableModule
{
    public class UserTable
    {
        public List<User> userTable = new List<User>();

        public void Add(User user)
        {
            userTable.Add(user);
        }
        public List<User> getTable()
        {
            return userTable;
        }
    }
}