using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Jie;

namespace DAL.LiuJIeDAL
{
    public class ProbaictSerivce
    {
        static CangChuEntities1 entity = new CangChuEntities1();

        /// <summary>
        /// 数据分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static Model.PageList PageListProbaict(int pageIndex, int pageSize) {
            Model.PageList list = new Model.PageList();
            var obj = from p in entity.Probaict
                      orderby p.ProId
                      select new
                      {
                          ProId = p.ProId,
                          ProName = p.ProName,
                          ProPrice = p.ProPrice,
                          PorGuiGe = p.PorGuiGe,
                          ProCId = from pp in entity.ProbaictCatagory where p.ProCId == pp.ProCId select pp.ProCName,
                          UnId = from ppp in entity.Unit where p.UnId == ppp.UnId select ppp.UnName,
                          CreateTime = p.CreateTime,
                          IsDelete = p.IsDelete,
                          ProNumber = p.ProNumber,
                          ProJinhuo = p.ProJinhuo,
                          ProChuhuo = p.ProChuhuo,
                          ProBaosun = p.ProBaosun,
                          Remake = p.Remake
                      };
            list.DataList = obj.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            int rows = entity.Probaict.Count();
            list.PageCount = rows % pageSize == 0 ? rows / pageSize : rows / pageSize + 1;
            return list;
        }

        /// <summary>
        /// 数据总条数
        /// </summary>
        /// <returns></returns>
        public static int GetRows() {
            return entity.Probaict.Count();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public static int GetDelete(string id) {
            var obj = (from p in entity.Probaict where p.ProId == id select p).First();
            entity.Probaict.Remove(obj);
            return entity.SaveChanges();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public static int Add(Probaict pr) {
            entity.Probaict.Add(pr);
            return entity.SaveChanges();
        }

        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <returns></returns>
        public static IQueryable GetById(string id) {
            var obj = from p in entity.Probaict
                      where p.ProId == id
                      select new
                      {
                          ProId = p.ProId,
                          ProName = p.ProName,
                          ProPrice = p.ProPrice,
                          PorGuiGe = p.PorGuiGe,
                          ProCId = from pp in entity.ProbaictCatagory where p.ProCId == pp.ProCId select pp.ProCName,
                          UnId = from ppp in entity.Unit where p.UnId == ppp.UnId select ppp.UnName,
                          CreateTime = p.CreateTime,
                          IsDelete = p.IsDelete,
                          ProNumber = p.ProNumber,
                          ProJinhuo = p.ProJinhuo,
                          ProChuhuo = p.ProChuhuo,
                          ProBaosun = p.ProBaosun,
                          Remake = p.Remake
                      };
            return obj;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public static int Update(Probaict pr) {
            var obj = (from p in entity.Probaict where pr.ProId == p.ProId select p).First();
            obj.ProId = pr.ProId;
            obj.ProName = pr.ProName;
            obj.ProPrice = pr.ProPrice;
            obj.PorGuiGe = pr.PorGuiGe;
            obj.ProCId = pr.ProCId;
            obj.UnId = pr.UnId;
            obj.CreateTime = pr.CreateTime;
            obj.IsDelete = pr.IsDelete;
            obj.ProNumber = pr.ProNumber;
            obj.ProJinhuo = pr.ProJinhuo;
            obj.ProChuhuo = pr.ProChuhuo;
            obj.ProBaosun = pr.ProBaosun;
            obj.Remake = pr.Remake;
            return entity.SaveChanges();
        }
    }
}
