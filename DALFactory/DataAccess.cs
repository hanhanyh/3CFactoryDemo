using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;
namespace DALFactory
{
    public class DataAccess
    {
        public static string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        #region 反射生成对象
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AssemblyPath">程序集名</param>
        /// <param name="classnameSpace">程序集下的类的完整命名空间</param>
        /// <returns></returns>
        public static object CreateObject(string AssemblyPath, string classnameSpace)
        {
            object obj = Assembly.Load(AssemblyPath).CreateInstance(classnameSpace);
            return obj;
        }
        #endregion
        #region 泛型生成
        /// <summary>
        /// 泛型生成
        /// </summary>
        /// <typeparam name="T">对应类型接口</typeparam>
        /// <param name="className">类名</param>
        /// <returns></returns>
        public static T Create<T>(string className)
        {
            string classNameSpace = AssemblyPath + "." + className;
            object obj = CreateObject(AssemblyPath, classNameSpace);
            return (T)obj;
        }
        #endregion
    }
}
