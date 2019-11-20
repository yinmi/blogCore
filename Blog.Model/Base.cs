using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;


namespace Blog.Model
{
    /// <summary>
    /// 所有表格共有属性
    /// 
    /// </summary>
    /// id
    /// 创建时间
    /// 是否删除
    public class Base
    {
        [SugarColumn(IsPrimaryKey=true,IsIdentity =true,ColumnDataType ="INT")]
        public int Id { get; set; }

        [SugarColumn(ColumnDataType = "DATETIME")]
        public DateTime dateTime { get; set; } = DateTime.Now;
       
        public string IsExist { get; set; } = "true";

    }
}
