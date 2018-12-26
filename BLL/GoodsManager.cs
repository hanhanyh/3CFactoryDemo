using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DALFactory;
using Models;
using IDAL;
namespace BLL
{
    /// <summary>
    /// 商品管理
    /// </summary>
    public class GoodsManager
    {
        public IGoodsSvr igd = DALFactory.DataAccess.Create<IGoodsSvr>("GoodsService");
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public IList<Goods> GetList()
        {
           return  igd.GetList();
        }
        /// <summary>
        /// 分页查询所有
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public IList<Goods> GetListPager(int skip, int max)
        {
            return igd.GetListPager(skip, max);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public object Insert(Models.Goods g)
        {
           return  igd.Insert(g);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="goods"></param>
        //public void update(Models.Goods goods)
        //{
        //    ISqlMapper mapper = Mapper.Instance();
        //    mapper.Update("updateGoods", goods);
        //}
        /// <summary>
        /// 模糊查询(根据名称)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IList<Goods> Search(Models.Goods key)
        {
            return igd.Search(key);

        }
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="goods"></param>
        public void Delete(Models.Goods goods)
        {
             igd.Delete(goods);
        }

        public int add(Goods entity)
        {
            return igd.add(entity);
        }

        public int delete(Goods entity)
        {
            return igd.delete(entity);
        }

        public Goods SelectById(int id)
        {
           return  igd.SelectById(id);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(Goods entity)
        {
         return    igd.Update(entity);
        }
    }
}
