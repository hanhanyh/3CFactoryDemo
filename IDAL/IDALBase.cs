using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
  public  interface IDALBase<T>
    {
        int add(T entity);
        int delete(T entity);
        T SelectById(int id);
        int Update(T entity);
    }
}
