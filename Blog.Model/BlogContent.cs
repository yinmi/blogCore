using System;
using System.Linq;
using SqlSugar;

namespace Blog.Model
{
    /*********
     * 数据库连接信息
     * 
     * 
     * */
    public class BlogContent
    {
       
        public BlogContent()
        {
            //连接数据库信息
             Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "server=localHost;uid=root;pwd=root;database=Blog2",
                DbType = DbType.MySql,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true
            });

            //打印SQL语句，调试用
             Db.Aop.OnLogExecuting = (sql, pars) =>
             {
                 Console.WriteLine(sql + "/r/n" + Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));

                 Console.WriteLine();
             };
          
        }

        //创建数据库
        public  bool CreateDatabase()
        {
            if(!Db.DbMaintenance.IsAnyTable("user"))
                Db.CodeFirst.SetStringDefaultLength(100).InitTables(typeof(User));

            if (!Db.DbMaintenance.IsAnyTable("category"))
                Db.CodeFirst.SetStringDefaultLength(100).InitTables(typeof(Category));

            if (!Db.DbMaintenance.IsAnyTable("categorytoarticle"))
                Db.CodeFirst.SetStringDefaultLength(100).InitTables(typeof(CategoryToArticle));

            if (!Db.DbMaintenance.IsAnyTable("comment"))
                Db.CodeFirst.SetStringDefaultLength(100).InitTables(typeof(Comment));

            if (!Db.DbMaintenance.IsAnyTable("article"))
                Db.CodeFirst.SetStringDefaultLength(100).InitTables(typeof(Article));

          

            return true; 
        }

        //多表查询
        public SqlSugarClient Db;

        
    }
}
