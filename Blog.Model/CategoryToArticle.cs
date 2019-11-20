using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Blog.Model
{
    /// <summary>
    /// 文章类型和文章对应
    /// </summary>
     public class CategoryToArticle:Base
    {
        [SugarColumn(ColumnDataType = "int")]
        public int ArticleId { get; set; }

        [SugarColumn(ColumnDataType = "int")]
        public int CategoryId { get; set; }
    }
}
