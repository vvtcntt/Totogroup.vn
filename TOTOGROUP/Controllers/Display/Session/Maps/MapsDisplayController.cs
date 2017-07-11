﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOTOGROUP.Models;
 namespace TOTO.Controllers.Display.Session.Maps
{
    public class MapsDisplayController : Controller
    {
        TOTOGROUPContext db = new TOTOGROUPContext();
        //
        // GET: /MapsDisplay/
        public ActionResult Index()
        {
             return View();
        }
       
        public ActionResult MapsDetail()
        {
            tblMap map = db.tblMaps.First();
            ViewBag.Title = "<title>" + map.Name + "</title>";
            ViewBag.Description = "<meta name=\"description\" content=\"" + map.Description + "\"/>";
            ViewBag.Keyword = "<meta name=\"keywords\" content=\"" + map.Name + "\" /> ";
            return View(map);

           
        }
	}
}