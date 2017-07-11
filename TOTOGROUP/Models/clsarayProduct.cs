using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOTOGROUP.Models
{
    public class clsarayProduct
    {
        
        public clsarayProduct()
        { 
        this.CartItem=new List<chkcheckProduct>();
        }
        public List<chkcheckProduct> CartItem
        {
            get;
            set;
        }
    }
}