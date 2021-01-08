using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Model.Jie;
using BLL.LiuJIeBLL;

namespace WebApplication1.Controllers
{
    public class LiuJieController : Controller
    {
        // GET: LiuJie
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PageListProbaict(int pageIndex, int pageSize) {
            return Json(ProbaictManager.PageListProbaict(pageIndex,pageSize),JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetRows() {
            return Json(ProbaictManager.GetRows(),JsonRequestBehavior.AllowGet);
        }
    }
}