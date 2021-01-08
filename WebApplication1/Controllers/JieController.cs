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
    public class JieController : Controller
    {
        // GET: Jie
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 产品页
        /// </summary>
        /// <returns></returns>
        public ActionResult ChanPing() {
            return View();
        }
        /// <summary>
        /// 产品数据分页
        /// </summary>
        /// <returns></returns>
        public ActionResult PageListProbaict(int pageIndex,int pageSize) {
            return Json(BLL.LiuJIeBLL.ProbaictManager.PageListProbaict(pageIndex,pageIndex),JsonRequestBehavior.AllowGet) ;
        }
        /// <summary>
        /// 数据条数
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRows() {
            return Json(ProbaictManager.GetRows(),JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetDelete(string id) {
            return Json(ProbaictManager.GetDelete(id),JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 产品新增页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ChanPingAdd() {
            return View();
        }

        /// <summary>
        /// 产品修改页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ChanPingUpdate() {
            return View();
        }

        /// <summary>
        /// 查询Unit表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUnit() {
            return Json(UnitManager.GetUnit(),JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 查询ProbaitCatagory表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetProbaitCatagory() {
            return Json(ProbaictCatagoryManager.GetProbaictCatagory(),JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public ActionResult Add(Probaict pr) {
            return Json(ProbaictManager.Add(pr),JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <returns></returns>
        public ActionResult GetById(string id) {
            return Json(ProbaictManager.GetById(id),JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public ActionResult Update(Probaict pr) {
            return Json(ProbaictManager.Update(pr),JsonRequestBehavior.AllowGet);
        }
    }
}