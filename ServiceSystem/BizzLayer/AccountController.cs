using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizzLayer
{
    public class AccountController
    {
        public class Account {
        public String username { get; set; }
        public String password { get; set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
        public DateTime retire_date { get; set; }
        public String role { get; set; }
        }

        static SqlConnection con = new SqlConnection("Data Source=KOMP;Initial Catalog=Service_System_DB;Integrated Security=True");

        public static bool NewAccount(Account new_account) {
            using (ServiceSystemDataContext dbContext = new ServiceSystemDataContext()) {
                PERSONEL new_personel = new PERSONEL
                {
                    fname = new_account.first_name,
                    lname = new_account.last_name,
                    username = new_account.username,
                    pass = new_account.password,
                    role = new_account.role,
                    dt_retire = new_account.retire_date
                };

                dbContext.PERSONEL.InsertOnSubmit(new_personel);
                try
                {
                    dbContext.SubmitChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }

            }

        }
    }
}
