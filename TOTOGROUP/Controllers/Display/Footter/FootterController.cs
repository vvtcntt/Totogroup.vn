using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TOTOGROUP.Models;
namespace TOTO.Controllers.Display.Footter
{
    public class FootterController : Controller
    {
        private TOTOGROUPContext db = new TOTOGROUPContext();
        // GET: Footter
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ControlFootter()
        {
            tblConfig tblconfig = db.tblConfigs.First();
            var Url = db.tblUrls.Where(p => p.Active == true).OrderBy(p => p.Ord).ToList();
            StringBuilder chuoi = new StringBuilder();
            for (int i = 0; i < Url.Count;i++ )
            {
                if(Url[i].Rel==true)
                { chuoi.Append("<a href=\"" + Url[i].Url + "\" title=\"" + Url[i].Name + "\" rel=\"nofollow\">" + Url[i].Name + "</a>"); }
                else
                chuoi.Append("<a href=\"" + Url[i].Url + "\" title=\"" + Url[i].Name + "\">" + Url[i].Name + "</a>");
            }
            ViewBag.chuoi = chuoi;
            var maps = db.tblMaps.First();
            ViewBag.maps = maps.Content;
            var Imagesadw = db.tblImages.Where(p => p.Active == true && p.idCate == 9).OrderByDescending(p => p.Ord).Take(1).ToList();
            if (Imagesadw.Count > 0)
                ViewBag.Chuoiimg = "<a href=\"" + Imagesadw[0].Url + "\" title=\"" + Imagesadw[0].Name + "\"><img src=\"" + Imagesadw[0].Images + "\" alt=\"" + Imagesadw[0].Name + "\" style=\"max-width:100%;\" /> </a>";
            string resultOut= "<div class=\"vvt\"><a href=\"http://kangaroochinhhang.vn\" title=\"Máy lọc nước Kangaroo\">Máy lọc nước Kangaroo</a> chính hãng <a href=\"http://kangaroochinhhang.vn/may-loc-nuoc-kangaroo-hydrogen\" title=\"Máy lọc nước Kangaroo Hydrogen\">Máy lọc nước Kangaroo Hydrogen</a> mới nhất 2018 <a href=\"http://kangaroochinhhang.vn/loi-loc-nuoc-kangaroo\" title=\"Lõi lọc nước Kangaroo\">Lõi lọc nước Kangaroo</a></div>";
            ViewBag.resultOut = resultOut;
            return PartialView(tblconfig);
        }
        public ActionResult Command(FormCollection collection, tblRegister registry)
        {
             string Name = collection["txtName"];
                string Hotline = collection["txtHotline"];
                string selectcate = collection["selectcate"];
                registry.Name = Name;
                registry.Mobile = Hotline;
                registry.idCate = int.Parse(selectcate);
                     db.tblRegisters.Add(registry);
                    db.SaveChanges();
                    Session["registry"] = "<script>$(document).ready(function(){ alert('Bạn đã đăng ký thành công') });</script>";
                 
            
            return Redirect("/Default/Index");
        }
        public PartialViewResult MenuMobine()
        {
            var listGroup = db.tblGroupProducts.Where(p => p.Active == true && p.Priority == true).OrderBy(p => p.Ord).ToList();
            StringBuilder chuoimenu = new StringBuilder();
            for (int i = 0; i < listGroup.Count; i++)
            {

                string tag = listGroup[i].Tag;

                chuoimenu.Append("<a href=\"/0/" + tag + "\" title=\"" + listGroup[i].Name + "\">" + listGroup[i].Name + "</a>");

            }
            ViewBag.chuimenu = chuoimenu;
            StringBuilder chuoi = new StringBuilder();
            var ListMenu = db.tblGroupProducts.Where(p => p.Active == true && p.ParentID==null).OrderBy(p => p.Ord).ToList();
            for (int i = 0; i < ListMenu.Count; i++)
            {
                chuoi.Append("<li><a href=\"/0/" + ListMenu[i].Tag + "\" title=\"" + ListMenu[i].Name + "\">" + ListMenu[i].Name + "</a>");
                int idCate = ListMenu[i].id;
                var listmenuchild = db.tblGroupProducts.Where(p => p.ParentID == idCate & p.Active == true).OrderBy(p => p.Ord).ToList();
                if (listmenuchild.Count > 0)
                {
                    chuoi.Append("<ul>");
                    for (int j = 0; j < listmenuchild.Count; j++)
                    {
                        chuoi.Append("<li><a href=\"/0/" + listmenuchild[j].Tag + "\" title=\"" + listmenuchild[j].Name + "\">" + listmenuchild[j].Name + "</a></li>");
                    }
                    chuoi.Append("</ul>");
                }
                chuoi.Append("</li>");
            }
            ViewBag.chuoi = chuoi;
            return PartialView();
        }
        public PartialViewResult callPartial()
        {
            return PartialView(db.tblConfigs.First());
        }
    }
}