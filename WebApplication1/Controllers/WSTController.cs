using Model;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class WSTController : Controller
    {
        // GET: WST
       //登录页面
        public ActionResult Login()
        {
            Session.Clear();
            return View();
        }
        //登录
        public ActionResult Logins(string name, string pwd) {
            if (BLL.WstBLL.WstLoginBLL.Login(name, pwd) > 0) {
                Session["name"] =name;
                Session.Timeout = 1;
            }
            return Json(BLL.WstBLL.WstLoginBLL.Login(name, pwd), JsonRequestBehavior.AllowGet);
            
        }


        public ActionResult welcome() {
            return View();
        }

        //首页
         public ActionResult Index() {
           
            if (Session["name"].ToString() != null)
            {
                string UserName = Session["name"].ToString();
                ViewBag.UserNames = UserName;
            }
            else {
                Response.Redirect("/WST/Login");
            }
           
          
         
            return View();
        }


        public ActionResult password() {
            return View();
        }

        

        public ActionResult Users(string UserName) {
            return Json(BLL.WstBLL.WstLoginBLL.GetUserName(UserName), JsonRequestBehavior.AllowGet);
        }

        //修改密码
        public ActionResult UpdataPwds(int id, string pwd) {
            return Json(BLL.WstBLL.WstLoginBLL.UpdatePwd(id, pwd), JsonRequestBehavior.AllowGet);
        }

        //个人信息
        public ActionResult UserMsessage()
        {
            return View();
        }
        //修改个人信息
        public ActionResult UserMessages(Admin admin)
        {
            return Json(BLL.WstBLL.WstLoginBLL.UpdataUser(admin), JsonRequestBehavior.AllowGet);
        }

        //库存清单
        public ActionResult Inventory() {
            return View();
        }
        public ActionResult Inventorys(string aname,string bname,int pagesize,int pageindex)  {
            ProbaictStorage proc = new ProbaictStorage();
            proc.Storehouse = new Storehouse();
            proc.Storehouse.StoreName = aname;
            proc.Probaict = new Probaict();
            proc.Probaict.ProName = bname;
            return Json(BLL.WstBLL.StatementBLL.PageLsitPro(proc, pagesize,pageindex),JsonRequestBehavior.AllowGet);
        }

        //库位类型
        public ActionResult StorType() {
            return Json(BLL.WstBLL.StatementBLL.StorType(), JsonRequestBehavior.AllowGet);
        }

        //货品统计视图
        public ActionResult GoodsStatistics() {
            return View();
        }

        public ActionResult GoodsStatisticss(Probaict pro, int pagesize,int pageindex) {
            return Json(BLL.WstBLL.StatementBLL.PageListHuo(pro,pagesize, pageindex),JsonRequestBehavior.AllowGet);
        }

        //入库视图
        public ActionResult Warehouse() {
            return View();
        }
        public ActionResult Warehouses(string VenName,int pagesize, int pageindex) {
            Warehouse war = new Warehouse();
            war.Vendor = new Vendor();
            war.Vendor.VenName = VenName;
            return Json(BLL.WstBLL.StatementBLL.PagelistWarehouse(war, pagesize, pageindex), JsonRequestBehavior.AllowGet);
        }
        //入库详情视图
        public ActionResult WarehouseDetails() {
            return View();
        }
        public ActionResult WarehouseDetailss(int id) {
            return Json(BLL.WstBLL.StatementBLL.Warhouse(id), JsonRequestBehavior.AllowGet);
        }
        public ActionResult WarhousePro(int ids) {
            return Json(BLL.WstBLL.StatementBLL.WarhousePro(ids), JsonRequestBehavior.AllowGet);
        }

        //出库报表
        public ActionResult Deliver() {
            return View();
        }
        public ActionResult Delivers(string name,int pagesize,int pageindex) {
            Deliver der = new Deliver();
            der.Customer = new Customer();
            der.Customer.CusName = name;
            return Json(BLL.WstBLL.StatementBLL.PagelistDeliver(der, pagesize, pageindex),JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeliversDetails()
        {
            return View();
        }
        public ActionResult Delives(int id) {
            return Json(BLL.WstBLL.StatementBLL.Deliver(id), JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeliverPro(int ids) {
            return Json(BLL.WstBLL.StatementBLL.DeliverPro(ids), JsonRequestBehavior.AllowGet);
        }



        //客户报表
        public ActionResult Customer() {
            return View();
        }
        public ActionResult Customers(string name,int pagesize,int pageindex) {
            Customer c = new Customer();
            c.CusName = name;
            return Json(BLL.WstBLL.StatementBLL.PagelistCustomer(c,pagesize,pageindex),JsonRequestBehavior.AllowGet);
        }
        public ActionResult CustomersDetails() {
            return View();
        }
        public ActionResult CustomersDetailss(int id) {
            return Json(BLL.WstBLL.StatementBLL.Customer(id), JsonRequestBehavior.AllowGet);
        }

        //供应商报表
        public ActionResult Vendor() {
            return View();
        }
        public ActionResult Vendors(string name, int pagesize, int pageindex) {
            Vendor ven = new Vendor();
            ven.VenName = name;
            return Json(BLL.WstBLL.StatementBLL.PagelistVendor(ven, pagesize, pageindex), JsonRequestBehavior.AllowGet);
        }
        
        //报损视图
        public ActionResult Damage()
        {
            return View();
        }
        public ActionResult Damages(string name,int pagesize,int pageindex)
        {
            Probaict pro = new Probaict();
            pro.ProName = name;
            return Json(BLL.WstBLL.StatementBLL.PagelistDamage(pro, pagesize, pageindex));
        }

        //退货视图
        public ActionResult Comeback()
        {
            return View();
        }
        public ActionResult Comebacks(string name, int pagesize, int pageindex) {
            Probaict pro = new Probaict();
            pro.ProName = name;
            return Json(BLL.WstBLL.StatementBLL.PagelistComeback(pro, pagesize, pageindex));
        }

    }
}