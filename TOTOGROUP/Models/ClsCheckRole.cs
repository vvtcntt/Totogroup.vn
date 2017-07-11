using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TOTOGROUP.Models;
namespace TOTOGROUP.Models
{
    public class ClsCheckRole
    {
         public static bool  CheckQuyen(int Module,int Role,int idUser)
        {
            TOTOGROUPContext db = new TOTOGROUPContext();
            var listRight = db.tblRights.Where(p => p.idUser == idUser && p.idModule == Module && p.Role ==Role).ToList();
            if (listRight.Count > 0)
            {
                
                 return true;
            }
            else
                return false;
        }
    }
 
}