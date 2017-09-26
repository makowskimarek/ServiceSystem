using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizzLayer
{
    public class ActivityController
    {
        public static bool AddNewActivity(ACTIVITY activity)
        {
            using (ServiceSystemDataContext dbContext = new ServiceSystemDataContext())
            {
                dbContext.ACTIVITY.InsertOnSubmit(activity);
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
