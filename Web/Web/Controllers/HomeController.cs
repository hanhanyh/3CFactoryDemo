using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
namespace Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public BLL.GoodsManager gm = new BLL.GoodsManager();
        public ActionResult Index()
        {

            
            //
            //IList<Goods> ilGoods = dao.Search(new Goods() { name="1"});
            //
            IList<Goods> lgoods= gm.GetList();
            ViewData["data"] = lgoods;
            //添加数据测试
            //Goods g = new Goods() { name = "testname", zl = 10, Description = "ddd", count = 55 };
            //dao.Insert(g);

            return View();
        }

    }
}
