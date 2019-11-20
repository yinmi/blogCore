using SqlSugar;
namespace Blog.Model
{
    /// <summary>
    /// 评论
    /// </summary>
    public  class Comment:Base
    {
        public string  CommentatorId { get; set; }

        [SugarColumn(ColumnDataType = "text")]
        public string  Content { get; set; }

        [SugarColumn(ColumnDataType = "int")]
        public int ArticleId { get; set; }
    }
}
