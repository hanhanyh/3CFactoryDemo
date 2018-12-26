using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
namespace Web.Controllers
{
    public class HandlersController : Controller
    {
        public BLL.GoodsManager gm = new BLL.GoodsManager();
        //
        // GET: /Handlers/
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="name"></param>
        /// <param name="des"></param>
        /// <param name="zl"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public ActionResult addGoods(string name, string des, int zl, int count)
        {

            object obj = gm.Insert(new Goods() { name = name, Description = des, zl = zl, count = count });
            return Content("1");
        }
        /// <summary>
        /// 获取所有商品
        /// </summary>
        /// <returns>Json</returns>
        public ActionResult getAllGoods()
        {
            IList<Goods> Lg = gm.GetList();
            string data = "";
            data += "{";
            data += "\"total\":" + Lg.Count + ",\"rows\":[";
            for (int i = 0; i < Lg.Count - 1; i++)
            {
                data += "{\"id\":\"" + Lg[i].id + "\",\"name\":\"" + Lg[i].name + "\",\"desc\":\"" + Lg[i].Description + "\",\"zl\":" + Lg[i].zl + ",\"count\":" + Lg[i].count + "},";
            }
            if (Lg.Count > 0)
                data += "{\"id\":\"" + Lg[Lg.Count - 1].id + "\",\"name\":\"" + Lg[Lg.Count - 1].name + "\",\"desc\":\"" + Lg[Lg.Count - 1].Description + "\",\"zl\":" + Lg[Lg.Count - 1].zl + ",\"count\":" + Lg[Lg.Count - 1].count + "}";
            data += "]}";
            return Content(data);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult update(Goods goods)
        {
            gm.Update(goods);
            return Content("1");
        }
        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ActionResult Search(string key)
        {
            ;
            IList<Goods> Lg = gm.Search(new Goods() { name = key });
            string data = "";
            data += "{";
            data += "\"total\":" + Lg.Count + ",\"rows\":[";
            for (int i = 0; i < Lg.Count - 1; i++)
            {
                data += "{\"id\":\"" + Lg[i].id + "\",\"name\":\"" + Lg[i].name + "\",\"desc\":\"" + Lg[i].Description + "\",\"zl\":" + Lg[i].zl + ",\"count\":" + Lg[i].count + "},";
            }
            if (Lg.Count > 0)
                data += "{\"id\":\"" + Lg[Lg.Count - 1].id + "\",\"name\":\"" + Lg[Lg.Count - 1].name + "\",\"desc\":\"" + Lg[Lg.Count - 1].Description + "\",\"zl\":" + Lg[Lg.Count - 1].zl + ",\"count\":" + Lg[Lg.Count - 1].count + "}";
            data += "]}";
            return Content(data);
        }
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult delete(int id)
        {
           
            gm.Delete(new Goods() { id = id });
            return Content("1");
        }
       /// <summary>
       /// 分页
       /// </summary>
       /// <param name="page"></param>
       /// <param name="rows"></param>
       /// <returns></returns>
        public ActionResult getGoodsListPager(int page, int rows)
        {

         
            IList<Goods> Lg=  gm.GetListPager((page - 1) * rows, rows);
            string data = "";
            data += "{";
            data += "\"total\":" + Lg.Count + ",\"rows\":[";
            for (int i = 0; i < Lg.Count - 1; i++)
            {
                data += "{\"id\":\"" + Lg[i].id + "\",\"name\":\"" + Lg[i].name + "\",\"desc\":\"" + Lg[i].Description + "\",\"zl\":" + Lg[i].zl + ",\"count\":" + Lg[i].count + "},";
            }
            if (Lg.Count > 0)
                data += "{\"id\":\"" + Lg[Lg.Count - 1].id + "\",\"name\":\"" + Lg[Lg.Count - 1].name + "\",\"desc\":\"" + Lg[Lg.Count - 1].Description + "\",\"zl\":" + Lg[Lg.Count - 1].zl + ",\"count\":" + Lg[Lg.Count - 1].count + "}";
            data += "]}";
            return Content(data);
        }
    }
}
