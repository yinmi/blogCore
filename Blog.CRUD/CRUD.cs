using System;
using Blog.Model;
using SqlSugar;
using System.Collections.Generic;

namespace Blog.CRUD
{
    public class DbCRUD<T>:BlogContent,ICRUD.ICRUD<T> where T :Base ,new() 
    {
        public SimpleClient<T> CurrentDb { get { return new SimpleClient<T>(Db); } }//用来处理T表的常用操作


        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public  ISugarQueryable<T> Get()
        {
            return Db.Queryable<T>().Where(it=>it.IsExist=="true");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  bool Delete(T obj , bool logout = true)
        {
            if(logout)
            {
                T result= Get().Where(it=>it.Id==obj.Id).First();
                result.IsExist = "false";

                return Update(result);
            }else
            {
               return CurrentDb.Delete(obj);
            }
            
        }


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  bool Update(T obj)
        {
            return CurrentDb.Update(obj);
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public  bool Inseart(T obj)
        {
            return Db.Insertable(obj).ExecuteCommandIdentityIntoEntity();
        }

    }
}

