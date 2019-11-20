using System;
using System.Collections.Generic;
using System.Text;
using Blog.DateToView;


namespace Blog.BLL
{
    public class ArticleServer:IArticleServer
    {
        private CRUD.ArticleManage articleManage;
        private CRUD.CategoryManage categoryManage;
        private CRUD.CommentManage commentManage;
        private CRUD.CTAManage CTAManage;
        public ArticleServer()
        {
            articleManage = new CRUD.ArticleManage();
            categoryManage = new CRUD.CategoryManage();
            commentManage = new CRUD.CommentManage();
            CTAManage = new CRUD.CTAManage();
        }

        //获得文章 
        public ArticleDate GetArticle(int id)
        {
           ArticleDate articleDate= articleManage.Get().Where(item => item.Id == id).Select(item => new ArticleDate()
            {
                 ArticleId=item.Id,
                 ArticleName=item.Name,
                  CreateTime=item.dateTime,
                  ArticleContent=item.Content
            }).First();

            var CTA = CTAManage.Get().
                Where(item => item.ArticleId == articleDate.ArticleId).
                ToList();

            List<string> Catagorys=new List<string>();

            CTA.ForEach(item => {
             Catagorys.Add(categoryManage.Get().
                Where(it => it.Id == item.CategoryId).
                Select(it => it.Name).First());
            });

            articleDate.Catagory = Catagorys;
            
            return articleDate;

        }

        //获取最新文章标题
        public List<ArticleDate> GetLatestArticleTitle()
        {
            return articleManage.Get().
                OrderBy(item => item.dateTime, SqlSugar.OrderByType.Desc)
                .Take(10).
                Select(item => new ArticleDate() {
                    ArticleId = item.Id,
                    ArticleName=item.Name,
                    UserId=item.UserId,
                    CreateTime=item.dateTime

                }).ToList();

        }

        

       

    }
}
