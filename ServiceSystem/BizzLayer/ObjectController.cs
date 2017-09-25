using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizzLayer
{
    public class ObjectController
    {
        public static bool AddNewObject(OBJECT obj)
        {
            using (ServiceSystemDataContext dbContext = new ServiceSystemDataContext())
            {
                dbContext.OBJECT.InsertOnSubmit(obj);
                try
                {
                    dbContext.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
