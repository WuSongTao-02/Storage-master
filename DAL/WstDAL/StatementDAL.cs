using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL.WstDAL
{
    public class StatementDAL
    {
        /// <summary>
        /// 库位类型
        /// </summary>
        /// <returns>数据集合</returns>
        public static IQueryable StorType() {
            CangChuEntities1 entity = new CangChuEntities1();
            var obj = from p in entity.Storehousetype select new {
                StId=  p.StId,
                StName=   p.StName,
            };
            return obj;
        }


        /// <summary>
        /// 库存清单报表
        /// </summary>
        /// <param name="pagesize">每页数据行</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        public static Model.WST.pagelist PageLsitPro(ProbaictStorage proc, int pagesize, int pageindex)
        {
            CangChuEntities1 entity = new CangChuEntities1();
            Model.WST.pagelist pagelist = new Model.WST.pagelist();
            var obj = from p in entity.ProbaictStorage
                      orderby p.Num
                      select new
                      {
                          StoreName = p.Storehouse.StoreName,
                          StName = from pp in entity.Storehousetype where pp.StId == p.Storehouse.StId select pp.StName,
                          StId = from stid in entity.Storehousetype where stid.StId == p.Storehouse.StId select stid.StId,
                          ProId = p.Probaict.ProId,
                          ProName=p.Probaict.ProName,
                          ProCName= from type in entity.ProbaictCatagory where type.ProCId== p.Probaict.ProCId select type.ProCName,
                          PorGuiGe=  p.Probaict.PorGuiGe,
                          Num= p.Num,
                             
                      };

            var row = 0;
            if (!string.IsNullOrEmpty(proc.Storehouse.StoreName)) {
                obj = obj.Where(p => p.StoreName.Contains(proc.Storehouse.StoreName));
            }
            if (!string.IsNullOrEmpty(proc.Probaict.ProName)) {
                obj = obj.Where(p => p.ProName.Contains(proc.Probaict.ProName));
            }
             row = obj.Count();
            pagelist.DataList= obj.Skip((pageindex - 1) * pagesize).Take(pagesize);
            pagelist.PageCount = row % pagesize == 0 ? row / pagesize : row / pagesize + 1;
            return pagelist;
        }

        /// <summary>
        /// 分页查询货品统计
        /// </summary>
        /// <param name="pagesize">每页数据行</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        public static Model.WST.pagelist PageListHuo(Probaict pro, int pagesize, int pageindex) {
            CangChuEntities1 entity = new CangChuEntities1();
            Model.WST.pagelist pagelist = new Model.WST.pagelist();
            var obj = from p in entity.Probaict
                      orderby p.ProId
                      select new
                      {
                          ProId = p.ProId,
                          ProName = p.ProName,
                          ProCName = p.ProbaictCatagory.ProCName,
                          PorGuiGe = p.PorGuiGe,
                          ProPrice = p.ProPrice,
                          ProCount = (from pp in entity.ProbaictStorage where pp.ProId == p.ProId select pp.Num).Sum(),
                          ProBaoSun = p.ProBaosun,
                          ProJinh =p.ProJinhuo,
                          ProChuh =p.ProChuhuo,
                      };

            var row = 0;
            if (!string.IsNullOrEmpty(pro.ProId)) {
                obj = obj.Where(p => p.ProId.Contains(pro.ProId));
                //row = (obj.Where(p => p.ProId.Contains(pro.ProId))).Count();
            }
            if (!string.IsNullOrEmpty(pro.ProName)) {
                obj = obj.Where(p => p.ProName.Contains(pro.ProName));
               // row = (obj.Where(p => p.ProId.Contains(pro.ProId))).Count();
            }
            row = obj.Count();
            pagelist.DataList = obj.Skip((pageindex - 1) * pagesize).Take(pagesize);
            pagelist.PageCount = row % pagesize == 0 ? row / pagesize : row / pagesize + 1;
            return pagelist;
        }


        /// <summary>
        /// 入库报表
        /// </summary>
        /// <param name="pagesize">每页数量</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        public static Model.WST.pagelist PagelistWarehouse(Warehouse war, int pagesize, int pageindex) {
            CangChuEntities1 entity = new CangChuEntities1();
            Model.WST.pagelist pagelist = new Model.WST.pagelist();
            var obj = from p in entity.Warehouse
                orderby p.WarId
                 select new {
                WarId= p.WarId,
                CreateTime=  p.CreateTime,
                VenName= p.Vendor.VenName,
                count=(from pp in entity.WarehouseStorage where pp.WarId ==p.WarId select p).Count(),
             };
            var row = 0;
            if (!string.IsNullOrEmpty(war.Vendor.VenName)) {
                obj = obj.Where(p => p.VenName == war.Vendor.VenName);
            }
          
            row = obj.Count();
            pagelist.DataList = obj.Skip((pageindex - 1) * pagesize).Take(pagesize);
            pagelist.PageCount = row % pagesize == 0 ? row / pagesize : row / pagesize + 1;
            return pagelist;

        }

        /// <summary>
        /// 根据入库订单号查询详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IQueryable Warhouse(int id)
        {
            CangChuEntities1 entity = new CangChuEntities1();
            var obj = from p in entity.Warehouse
                      where p.WarId == id
                      select new
                      {
                          WarId = p.WarId,
                          WarType = p.WarType,
                          AudiName = p.Auditing.AudiName,
                          VenId = p.VenId,
                          VenName = p.Vendor.VenName,
                          VenPerson = p.Vendor.VenPerson,
                          WarOrder = p.WarOrder,
                          WarPerson = p.WarPerson,
                          CreateTime = p.CreateTime,
                          VenTel = p.Vendor.VenTel,
                          Remake = p.Remake,
                      };
            return obj;
        }


        /// <summary>
        /// 入库订单产品详情
        /// </summary>
        /// <param name="id">入库id</param>
        /// <returns>数据集</returns>
        public static IQueryable WarhousePro(int id)
        {
            CangChuEntities1 entity = new CangChuEntities1();
            var obj = from p in entity.WarehouseStorage
                      where p.WarId == id
                      select new
                      {
                          ProName = p.Probaict.ProName,
                          PorGuiGe = p.Probaict.PorGuiGe,
                          ProPrice = p.Probaict.ProPrice,
                          WarRukuNum = p.WarRukuNum,
                      };
            return obj;
        }


        /// <summary>
        /// 出库报表
        /// </summary>
        /// <param name="del">对象</param>
        /// <param name="pagesize">每页数</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        public static Model.WST.pagelist PagelistDeliver(Deliver del,int pagesize,int pageindex) {
            CangChuEntities1 entity = new CangChuEntities1();
            Model.WST.pagelist pagelist = new Model.WST.pagelist();
            var obj = from p in entity.Deliver
                      orderby p.DeliId
                      select new {
                          DeliId = p.DeliId,
                          CreateTime= p.CreateTime,
                          CusName= p.Customer.CusName,
                         count = (from pp in entity.DeliverStorage where pp.DeliId == p.DeliId select p).Count(),
                      };
            var row = 0;
            if (!string.IsNullOrEmpty(del.Customer.CusName)) {
                obj = obj.Where(p => p.CusName.Contains(del.Customer.CusName));
            }
            row = obj.Count();
            pagelist.DataList = obj.Skip((pageindex - 1) * pagesize).Take(pagesize);
            pagelist.PageCount = row % pagesize == 0 ? row / pagesize : row / pagesize + 1;
            return pagelist;
        }
 
        /// <summary>
        /// 出库详情
        /// </summary>
        /// <param name="id">出库id</param>
        /// <returns>数据集合</returns>
        public static IQueryable Deliver(int id)
        {
            CangChuEntities1 entity = new CangChuEntities1();
            var obj = from p in entity.Deliver
                      where p.DeliId == id
                      select new
                      {
                          DeliId=p.DeliId,
                          DeliType=p.DeliType,
                          AudiName= p.Auditing.AudiName,
                          CusId=p.CusId,
                          CusName= p.Customer.CusName,
                          DeliaOrder=p.DeliaOrder,
                          DeliPerson=p.DeliPerson,
                          CreateTime=p.CreateTime,
                          CusTel=p.Customer.CusTel,
                          address=p.address,
                      };
            return obj;
        }

        /// <summary>
        /// 出库产品详情
        /// </summary>
        /// <param name="id">出库编号</param>
        /// <returns>数据集合</returns>
        public static IQueryable DeliverPro(int id)
        {
            CangChuEntities1 entity = new CangChuEntities1();
            var obj = from p in entity.DeliverStorage
                      where p.DeliId == id
                      select new
                      {
                          p.Probaict.ProName,
                          p.Probaict.ProPrice,
                          p.Probaict.PorGuiGe,
                          p.ProChukNum,


                      };
            return obj;

        }

        /// <summary>
        /// 客户报表
        /// </summary>
        /// <param name="cus">客户对象</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        public static Model.WST.pagelist PagelistCustomer(Customer cus, int pagesize, int pageindex)
        {
            CangChuEntities1 entity = new CangChuEntities1();
            Model.WST.pagelist pagelist = new Model.WST.pagelist();
            var obj = from p in entity.Customer
                      orderby p.CusId
                      where p.IsDelete == 0
                      select new
                      {
                          CusId = p.CusId,
                          CusName = p.CusName,
                          CusTel = p.CusTel,
                          CreateTime = p.CreateTime,
                          CusNum = p.CusNum,
                      };
            var row = 0;
            if (!string.IsNullOrEmpty(cus.CusName))
            {
                obj = obj.Where(p => p.CusName.Contains(cus.CusName));
            }
            row = obj.Count();
            pagelist.DataList = obj.Skip((pageindex - 1) * pagesize).Take(pagesize);
            pagelist.PageCount = row % pagesize == 0 ? row / pagesize : row / pagesize + 1;
            return pagelist;
        }

        /// <summary>
        /// 客户报表详情
        /// </summary>
        /// <param name="id">客户编号</param>
        /// <returns></returns>
        public static IQueryable Customer(int id) {
            CangChuEntities1 entity = new CangChuEntities1();
            var obj = from p in entity.CustomerAdd
                      where p.CusId == id
                      select new {
                          CusId= p.CusId,
                          CusName=p.Customer.CusName,
                          Remanke= p.Customer.Remanke,
                          CusTel=p.Customer.CusTel,
                          email= p.Customer.email,
                          CusadId= p.CusadId,
                          CusadAddress= p.CusadAddress,
                          CusadPerson= p.CusadPerson,
                          CusadTel= p.CusadTel,
                      };
            return obj;
        }



        /// <summary>
        /// 供应商报表
        /// </summary>
        /// <param name="ven">供应商对象</param>
        /// <param name="pagesize">每页数</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        public static Model.WST.pagelist PagelistVendor(Vendor ven, int pagesize, int pageindex) {
            CangChuEntities1 entity = new CangChuEntities1();
            Model.WST.pagelist pagelist = new Model.WST.pagelist();
            var obj = from p in entity.Vendor
                      orderby p.VenId
                      select new
                      {
                          VenName=  p.VenName,
                          VenTel= p.VenTel,
                          VenEmain= p.VenEmain,
                          VenPerson= p.VenPerson,
                          VenAddress=  p.VenAddress,
                          Remake= p.Remake,

                      };
            var row = 0;
            if (!string.IsNullOrEmpty(ven.VenName))
            {
                obj = obj.Where(p => p.VenName.Contains(ven.VenName));
            }
            row = obj.Count();
            pagelist.DataList = obj.Skip((pageindex - 1) * pagesize).Take(pagesize);
            pagelist.PageCount = row % pagesize == 0 ? row / pagesize : row / pagesize + 1;
            return pagelist;
        }

        /// <summary>
        /// 报损报表
        /// </summary>
        /// <param name="pro">商品对象</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        public static Model.WST.pagelist PagelistDamage(Probaict pro,int pagesize,int pageindex) {
            CangChuEntities1 entity = new CangChuEntities1();
            Model.WST.pagelist pagelist = new Model.WST.pagelist();
            var obj = from p in entity.Probaict
                      where p.ProBaosun!=0
                      orderby p.ProBaosun
                      select new {
                          ProId= p.ProId,
                          ProName=  p.ProName,
                          ProBaosun= p.ProBaosun,
                          Sum= (p.ProBaosun*p.ProPrice),
                          ProNumber=p.ProNumber,
                      };
            var row = 0;
            if (!string.IsNullOrEmpty(pro.ProName)) {
                obj = obj.Where(p => p.ProName.Contains(pro.ProName));
            }
            row = obj.Count();
            pagelist.DataList = obj.Skip((pageindex - 1) * pagesize).Take(pagesize);
            pagelist.PageCount = row % pagesize == 0 ? row / pagesize : row / pagesize + 1;
            return pagelist;
        }


        /// <summary>
        /// 退货报表
        /// </summary>
        /// <param name="pro">商品对象</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        public static Model.WST.pagelist PagelistComeback(Probaict pro, int pagesize, int pageindex) {
            CangChuEntities1 entity = new CangChuEntities1();
            Model.WST.pagelist pagelist = new Model.WST.pagelist();
            var obj = from p in entity.Probaict
                      where p.ProTuihuo!=0
                      orderby p.ProTuihuo
                      select new {
                          ProId = p.ProId,
                          ProName = p.ProName,
                          ProTuihuo= p.ProTuihuo,
                          Sum = (p.ProTuihuo * p.ProPrice),
                          ProNumber = p.ProNumber,

                      };
            var row = 0;
            if (!string.IsNullOrEmpty(pro.ProName))
            {
                obj = obj.Where(p => p.ProName.Contains(pro.ProName));
            }
            row = obj.Count();
            pagelist.DataList = obj.Skip((pageindex - 1) * pagesize).Take(pagesize);
            pagelist.PageCount = row % pagesize == 0 ? row / pagesize : row / pagesize + 1;
            return pagelist;
        }

    }


   
}
