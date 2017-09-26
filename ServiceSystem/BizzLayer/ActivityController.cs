using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizzLayer
{
    public class ActivityController
    {
        public class Activity
        {
            public int id_act { get; set; }
            public int id_req { get; set; }
            public int id_wrk { get; set; }
            public String act_type { get; set; }
            public int seq_no { get; set; }
            public String descr { get; set; }
            public String result { get; set; }
            public String status { get; set; }
            public DateTime dt_req { get; set; }
            public DateTime dt_fin_cancel { get; set; }

        }

        public class ActivityWithName
        {
            public int id_act { get; set; }
            public int id_req { get; set; }
            public int id_wrk { get; set; }
            public String act_type { get; set; }
            public String fname { get; set; }
            public String lname { get; set; }
            public String role { get; set; }
            public int seq_no { get; set; }
            public String descr { get; set; }
            public String result { get; set; }
            public String status { get; set; }
            public DateTime dt_req { get; set; }
            public DateTime dt_fin_cancel { get; set; }


        }

        public class SearchActivityByObject
        {
            public String act_type { get; set; }
            public int id_req { get; set; }
            public String name_type { get; set; }
            public String code_type { get; set; }
        }

        public class ActivityDict
        {
            public String act_type { get; set; }
            public String act_name { get; set; }
        }

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

        public static String[] GetAllActivityTypesNames()
        {
            using (ServiceSystemDataContext dbContext = new ServiceSystemDataContext())
            {
                try
                {
                    var activityTypes = from a in dbContext.ACT_DICT
                                        select a;
                    String[] actNames = new String[activityTypes.Count()];
                    List<ACT_DICT> activityTypesNames = activityTypes.ToList();

                    int i = 0;
                    foreach (ACT_DICT name in activityTypesNames)
                    {
                        actNames[i] = name.act_name;
                        i++;
                    }
                    return actNames;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static String getActivityByName(String activityName)
        {
            if (!activityName.Equals(null) && !activityName.Equals("")){
                using (ServiceSystemDataContext dbContext = new ServiceSystemDataContext())
                {
                    try
                    {
                        var activityTypes = from a in dbContext.ACT_DICT
                                            select a;
                        if (activityTypes.Count() > 0)
                        {
                            activityTypes = activityTypes.Where(a => a.act_name == activityName);

                            List<ACT_DICT> activityTypesNames = activityTypes.ToList();
                            return activityTypesNames.Last().act_type;
                        }
                        else return null;
                    }
                    catch (Exception ex)
                    {
                        Console.Out.Write("Exception in database");
                        return null;
                    }
                }
            }else
            {
                Console.Out.Write("Empty string");
                return null;
            }
            
        }

        //public static List<ActivityWithName> GetActivityBySearchCriteria(SearchActivityByObject srchCriteria)
        //{
        //    if (!srchCriteria.Equals(null))
        //    {
        //        using (ServiceSystemDataContext dbContext = new ServiceSystemDataContext())
        //        {
        //            try
        //            {
        //                var activities = (from a in dbContext.ACTIVITY
        //                                  join p in dbContext.PERSONEL
        //                                  on a.id_wrk equals p.id_pers
        //                                  join r in dbContext.REQUEST
        //                                  on a.id_req equals r.id_req
        //                                  join o in dbContext.OBJECT
        //                                  on r.nr_obj equals o.nr_obj
        //                                  join ot in dbContext.OBJ_TYPE
        //                                  on o.code_type equals ot.code_type
        //                                  into ap
        //                                  from ot in ap.DefaultIfEmpty()
        //                                  select new
        //                                  {
        //                                      act_type = a.act_type,
        //                                      id_act = a.id_act,
        //                                      id_req = a.id_req,
        //                                      id_wrk = a.id_wrk,
        //                                      seq_no = a.seq_no,
        //                                      descr = a.descr,
        //                                      result = a.result,
        //                                      status = a.status,
        //                                      dt_req = a.dt_req,
        //                                      dt_fin_cancel = a.dt_fin_cancel,
        //                                      fname = p.fname,
        //                                      lname = p.lname,
        //                                      role = p.role,
        //                                      code_type = o.code_type,

        //                                  });


                        
        //                if (activities.Count() > 0)
        //                {
        //                    activities = activities.Where(a => a.act_type == srchCriteria.act_type);

        //                    if (srchCriteria.act_type.Length != 0)
        //                    {
        //                        activities = activities.Where(a => a.act_type == srchCriteria.act_type);
        //                    }
        //                    if (srchCriteria.fname.Length != 0)
        //                    {
        //                        activities = activities.Where(a => a.fname == srchCriteria.fname);
        //                    }
        //                    if (srchCriteria.id_act >0)
        //                    {
        //                        activities = activities.Where(a => a.id_act == srchCriteria.id_act);
        //                    }
        //                    ActivityWithName activ = new ActivityWithName();
        //                    var activitiesResult = activities.ToList();
        //                    List<ActivityWithName> activitesWithName = new List<ActivityWithName>();
        //                    int i = 0;
        //                    foreach (var actResult in activitiesResult) { 

        //                        ActivityWithName act = new ActivityWithName();
        //                        act.id_act = actResult.id_act;
        //                        act.id_req = actResult.id_req;
        //                        act.id_wrk = actResult.id_wrk;
        //                        act.act_type = actResult.act_type;
        //                        act.seq_no = actResult.seq_no;
        //                        act.descr = actResult.descr;
        //                        act.result = actResult.result;
        //                        act.status = actResult.status;
        //                        act.dt_req = actResult.dt_req;
        //                        act.dt_fin_cancel = (DateTime) actResult.dt_fin_cancel;
        //                        act.fname = actResult.fname;
        //                        act.lname = actResult.lname;
        //                        act.role = actResult.role;

        //                        activitesWithName.Add(act);
        //                    }
        //                    return activitesWithName;

        //                }
        //                else return null;
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.Out.Write("Exception in database");
        //                return null;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Console.Out.Write("Empty string");
        //        return null;
        //    }
        //}
    }
}
