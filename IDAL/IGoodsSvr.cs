using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
namespace IDAL
{
   public  interface IGoodsSvr:IDALBase<Goods>
    {
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
         IList<Goods> GetList();
        /// <summary>
        /// 分页查询所有
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="max"></param>
        /// <returns></returns>
         IList<Goods> GetListPager(int skip, int max);
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
         object Insert(Models.Goods g);

        /// <summary>
        /// 模糊查询(根据名称)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
         IList<Goods> Search(Models.Goods key);
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="goods"></param>
         void Delete(Models.Goods goods);
    }
}
