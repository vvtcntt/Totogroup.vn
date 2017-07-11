using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TOTOGROUP.Models;

namespace TOTO.Controllers.Display.Header
{
    public class HeaderController : Controller
    {
        private TOTOGROUPContext db = new TOTOGROUPContext();
        // GET: Header
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ControlHeader()
        {
            return PartialView();
        }
        public PartialViewResult PartialSearch()
        {
            return PartialView();
        }
        public PartialViewResult Partialsidebar()
        {
            tblConfig tblconfig = db.tblConfigs.First();
            var listMenu = db.tblGroupProducts.Where(p => p.Active == true && p.ParentID==null).OrderBy(p => p.Ord).ToList();
            StringBuilder chuoi = new StringBuilder();
            for (int i = 0; i < listMenu.Count; i++)
            {
                chuoi.Append(" <li class=\"li1\">");
                chuoi.Append(" <a href=\"/0/" + listMenu[i].Tag + "\" title=\"" + listMenu[i].Name + "\">› " + listMenu[i].Name + "</a>");
                int idCate = listMenu[i].id;
                var listMenu1 = db.tblGroupProducts.Where(p => p.ParentID == idCate && p.Active == true).OrderBy(p => p.Ord).ToList();
                if (listMenu1.Count > 0)
                {
                    chuoi.Append("<ul>");
                    for (int j = 0; j < listMenu1.Count; j++)
                    {
                        chuoi.Append("<li><a href=\"/0/" + listMenu1[j].Tag + "\" title=\"" + listMenu1[j].Name + "\">" + listMenu1[j].Name + "</a></li>");
                    }
                    chuoi.Append("</ul>");
                }
                chuoi.Append("</li>");
            }
            ViewBag.chuoi = chuoi;
            return PartialView(tblconfig);
        }
        public PartialViewResult PartialBanner()
        {
            tblConfig tblconfig = db.tblConfigs.First();
            return PartialView(tblconfig);
        }
        public PartialViewResult ParitalMenuWidth()
        {
            string nStyle = "";
            var MenuParent = db.tblGroupProducts.Where(p => p.Active == true && p.ParentID ==null).OrderBy(p => p.Ord).ToList();
            StringBuilder chuoi = new StringBuilder();
            for (int i = 0; i < MenuParent.Count; i++)
            {
                if (i > 3)
                    nStyle = "style=\"right:0px\"";
                chuoi.Append(" <li class=\"li1\">");
                
                    chuoi.Append(" <a href=\"/0/" + MenuParent[i].Tag + "\" title=\"" + MenuParent[i].Name + "\">" + MenuParent[i].Name + "</a>");

                    int idCate = MenuParent[i].id;
                var listMenu = db.tblGroupProducts.Where(p => p.ParentID==idCate&& p.Active == true  ).OrderBy(p => p.Ord).ToList();
                if (listMenu.Count > 0)
                {
                    chuoi.Append("<ul class=\"ul2\" " + nStyle + ">");
                    for (int j = 0; j < listMenu.Count; j++)
                    {
                        chuoi.Append("<li class=\"li2\">");

                        chuoi.Append("<a class=\"image\" href=\"/0/" + listMenu[j].Tag + "\" title=\"\"><img src=\"" + listMenu[j].Images + "\" alt=\"" + listMenu[j].Name + "\" title=\"" + listMenu[j].Name + "\" /></a>");
                        chuoi.Append("<div class=\"Line\"></div>");
                        chuoi.Append("<a href=\"/0/" + listMenu[j].Tag + "\" title=\"" + listMenu[j].Name + "\">" + listMenu[j].Name + "</a>");
                   
                        chuoi.Append("</li>");
                    }
                    chuoi.Append("</ul>");
                }
                chuoi.Append("</li>");

            }
            ViewBag.chuoi = chuoi;
                return PartialView();
        }
        public PartialViewResult PatialHeader()
        {
            var listimageslide = db.tblImages.Where(p => p.Active == true && p.idCate == 1).OrderByDescending(p => p.Ord).Take(4).ToList();
            StringBuilder chuoislide = new StringBuilder();
            for (int i = 0; i < listimageslide.Count; i++)
            {
                if (i == 0)
                {
                    chuoislide.Append("url(" + listimageslide[i].Images + ") " + (770 * i) + "px 0 no-repeat");
                }
                else
                {

                    chuoislide.Append(", url(" + listimageslide[i].Images + ") " + (770 * i) + "px 0 no-repeat");
                }
            }
            ViewBag.chuoislide = chuoislide;
            var listnew = db.tblNews.Where(p => p.Active == true && p.ViewHomes == true).OrderByDescending(p => p.DateCreate).Take(2).ToList();
            StringBuilder chuoi = new StringBuilder();
            for (int i = 0; i < listnew.Count; i++)
            {
                chuoi.Append("<a href=\"/3/"+listnew[i].Tag+"\" title=\"" + listnew[i].Name + "\">- " + listnew[i].Name + "</a>");

            }
            ViewBag.chuoi = chuoi;

            return PartialView(listimageslide);
        }
    }
}