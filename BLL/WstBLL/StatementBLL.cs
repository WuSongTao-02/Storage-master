using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL.WstBLL
{
    public class StatementBLL
    {

        /// <summary>
        /// 库位类型
        /// </summary>
        /// <returns>数据集合</returns>
        public static IQueryable StorType()
        {
            return DAL.WstDAL.StatementDAL.StorType();
        }

            /// <summary>
            /// 分页查询货品统计
            /// </summary>
            /// <param name="pagesize">每页数据行</param>
            /// <param name="pageindex">页码</param>
            /// <returns></returns>
            public static Model.WST.pagelist PageListHuo(Probaict pro ,int pagesize, int pageindex)
        {
            return DAL.WstDAL.StatementDAL.PageListHuo(pro, pagesize, pageindex);
        }


        /// <summary>
        /// 库存清单报表
        /// </summary>
        /// <param name="pagesize">每页数据行</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        public static Model.WST.pagelist PageLsitPro(ProbaictStorage proc, int pagesize, int pageindex)
        {
            return DAL.WstDAL.StatementDAL.PageLsitPro(proc, pagesize, pageindex);
        }



        /// <summary>
        /// 入库报表
        /// </summary>
        /// <param name="pagesize">每页数量</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        public static Model.WST.pagelist PagelistWarehouse(Warehouse war, int pagesize, int pageindex)
        {
            return DAL.WstDAL.StatementDAL.PagelistWarehouse(war,pagesize, pageindex);
        }

        /// <summary>
        /// 根据入库订单号查询详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IQueryable Warhouse(int id)
        {
            return DAL.WstDAL.StatementDAL.Warhouse(id);
        }


        /// <summary>
        /// 入库订单产品详情
        /// </summary>
        /// <param name="id">入库id</param>
        /// <returns>数据集</returns>
        public static IQueryable WarhousePro(int id)
        {
            return DAL.WstDAL.StatementDAL.WarhousePro(id);
        }

        /// <summary>
        /// 出库报表
        /// </summary>
        /// <param name="del">对象</param>
        /// <param name="pagesize">每页数</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        public static Model.WST.pagelist PagelistDeliver(Deliver del, int pagesize, int pageindex)
        {
            return DAL.WstDAL.StatementDAL.PagelistDeliver(del, pagesize, pageindex);
        }

        /// <summary>
        /// 出库详情
        /// </summary>
        /// <param name="id">出库id</param>
        /// <returns>数据集合</returns>
        public static IQueryable Deliver(int id)
        {
            return DAL.WstDAL.StatementDAL.Deliver(id);
        }
        /// <summary>
        /// 出库产品详情
        /// </summary>
        /// <param name="id">出库编号</param>
        /// <returns>数据集合</returns>
        public static IQueryable DeliverPro(int id)
        {
            return DAL.WstDAL.StatementDAL.DeliverPro(id);
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
            return DAL.WstDAL.StatementDAL.PagelistCustomer(cus, pagesize, pageindex);
        }

        /// <summary>
        /// 客户报表详情
        /// </summary>
        /// <param name="id">客户编号</param>
        /// <returns></returns>
        public static IQueryable Customer(int id)
        {
            return DAL.WstDAL.StatementDAL.Customer(id);
        }


        /// <summary>
        /// 供应商报表
        /// </summary>
        /// <param name="ven">供应商对象</param>
        /// <param name="pagesize">每页数</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        public static Model.WST.pagelist PagelistVendor(Vendor ven, int pagesize, int pageindex)
        {
            return DAL.WstDAL.StatementDAL.PagelistVendor(ven, pagesize, pageindex);
        }

        /// <summary>
        /// 报损报表
        /// </summary>
        /// <param name="pro">商品对象</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        public static Model.WST.pagelist PagelistDamage(Probaict pro, int pagesize, int pageindex)
        {
            return DAL.WstDAL.StatementDAL.PagelistDamage(pro, pagesize, pageindex);
        }

        /// <summary>
        /// 退货报表
        /// </summary>
        /// <param name="pro">商品对象</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        public static Model.WST.pagelist PagelistComeback(Probaict pro, int pagesize, int pageindex)
        {
            return DAL.WstDAL.StatementDAL.PagelistComeback(pro, pagesize, pageindex);
        }
        }
}
