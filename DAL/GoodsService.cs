using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using IDAL;
using IBatisNet.Common;
using IBatisNet.DataAccess;
using IBatisNet.DataMapper;
namespace DAL
{
   public  class GoodsService:IGoodsSvr
    {
       /// <summary>
       /// 获取所有
       /// </summary>
       /// <returns></returns>
       public IList<Goods> GetList()
       {
           ISqlMapper mapper = Mapper.Instance();
           IList<Goods> ListGoods = mapper.QueryForList<Goods>("SelectAllGoods", null);
           return ListGoods;
       }
       /// <summary>
       /// 分页查询所有
       /// </summary>
       /// <param name="skip"></param>
       /// <param name="max"></param>
       /// <returns></returns>
       public IList<Goods> GetListPager(int skip,int max)
       {
           ISqlMapper mapper = Mapper.Instance();
           IList<Goods> ListGoods = mapper.QueryForList<Goods>("SelectAllGoods", null, skip, max);
           return ListGoods;
       }
       /// <summary>
       /// 新增
       /// </summary>
       /// <param name="g"></param>
       /// <returns></returns>
       public object Insert(Models.Goods g)
       {
           ISqlMapper mapper=Mapper.Instance();
          return   mapper.Insert("InsertGoods",g);
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
           ISqlMapper mapper = Mapper.Instance();
           return mapper.QueryForList<Goods>("searchGoods", key);

       }
       /// <summary>
       /// 删除商品
       /// </summary>
       /// <param name="goods"></param>
       public void Delete(Models.Goods goods)
       {
           ISqlMapper mapper = Mapper.Instance();
           mapper.Delete("deleteGoods", goods);
       }

       public int add(Goods entity)
       {
           throw new NotImplementedException();
       }

       public int delete(Goods entity)
       {
           throw new NotImplementedException();
       }

       public Goods SelectById(int id)
       {
           throw new NotImplementedException();
       }
       /// <summary>
       /// 更新
       /// </summary>
       /// <param name="entity"></param>
       /// <returns></returns>
       public int Update(Goods entity)
       {
           ISqlMapper mapper = Mapper.Instance();
           mapper.Update("updateGoods", entity);
           return 1;
       }
    }
}
