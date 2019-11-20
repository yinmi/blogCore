using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Blog.ICRUD
{
    //增删减查接口
    public interface ICRUD<T> where T :Model.Base
    {
         ISugarQueryable<T> Get();

         bool Delete(T obj , bool logout=true );

         bool Update(T obj);

         bool Inseart(T obj);

    }
}
