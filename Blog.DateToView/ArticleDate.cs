using System;
using System.Collections.Generic;

namespace Blog.DateToView
{
    //文章数据
    public class ArticleDate
    {
        public string ArticleName { get; set; }
         
        public int  UserId { get; set; }

        public int ArticleId { get; set; }

        public  string ArticleContent { get; set; }
       
        public List<string> Catagory { get; set; }

        public DateTime CreateTime { get; set; }

        public string UserName { get; set; }
        
    }
    
    
   
    //评论数据
    public class CommentDate
    {
        public string UserName { get; set; }

        public string Content { get; set; }

        public int ArticleId { get; set; }
    }
}
