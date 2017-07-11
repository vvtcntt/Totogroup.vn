using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TOTOGROUP.Models;
namespace TOTOGROUP.Models
{
    public class Updatehistoty
    {
        public TOTOGROUPContext db = new TOTOGROUPContext();
        public static void UpdateHistory(string task,string FullName,string UserID)
        {

            TOTOGROUPContext db = new TOTOGROUPContext();
            tblHistoryLogin tblhistorylogin = new tblHistoryLogin();
            tblhistorylogin.FullName = FullName;
            tblhistorylogin.Task = task;
            tblhistorylogin.idUser = int.Parse(UserID);
            tblhistorylogin.DateCreate = DateTime.Now;
            tblhistorylogin.Active = true;
            
            db.tblHistoryLogins.Add(tblhistorylogin);
            db.SaveChanges();
           
        }
    }
}