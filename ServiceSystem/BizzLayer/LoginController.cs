﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizzLayer
{
    public class LoginController
    {
        public static bool Login(String username, String password, String role)
        {
            ServiceSystemDataContext dbContext = new ServiceSystemDataContext();
            var query = from p in dbContext.PERSONEL
                        where p.username.Equals(username)
                        where p.pass.Equals(password)
                        where p.role.Equals(role)
                        select p;

            if (query.Count() == 1)
            {
                return true;
            }
            return false;
        }
    }
}
