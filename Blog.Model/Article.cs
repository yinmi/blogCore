using SqlSugar;

namespace Blog.Model
{
    /// <summary>
    /// 文章
    /// </summary>
    public class Article:Base
    {
        public string Name { get; set; }

        [SugarColumn(ColumnDataType ="text")]
        public string Content { get; set; }

        [SugarColumn(ColumnDataType ="int")]
        public int UserId { get; set; }
    }
}
