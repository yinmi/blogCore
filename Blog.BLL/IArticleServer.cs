using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.BLL
{
    public interface IArticleServer
    {
        //获取最新的文章名称
       List<DateToView.ArticleDate> GetLatestArticleTitle();

        //获取文章
        DateToView.ArticleDate GetArticle(int id);
    }
}
