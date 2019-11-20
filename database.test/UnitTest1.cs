using NUnit.Framework;
using System;
using System.Linq;


namespace Tests
{
    //用户表测试
    public class UserTableTest
    {
        public Blog.ICRUD.ICRUD<Blog.Model.User> userManage;

        [SetUp]
        public void Setup()
        {
           userManage = new Blog.CRUD.UserManage();
            var Db = new Blog.Model.BlogContent();
            Db.CreateDatabase();
        }
       //测试user插入
        [Test]
        public void InsertTest()
        {
             
            Blog.Model.User user = new Blog.Model.User()
            {
                Name = "小米",
                Email="6212@qq.com",
                Password="123456",
                path="",
            };
            var lk= userManage.Inseart(user);
            Assert.AreEqual(lk, true);

            user = new Blog.Model.User()
            {
                Name = "小红",
                Email = "6252@qq.com",
                Password = "123456",
                path = "",
            };
            var lk2 = userManage.Inseart(user);
            Assert.AreEqual(lk2, true);

            user = new Blog.Model.User()
            {
                Name = "小啦",
                Email = "621152@qq.com",
                Password = "123456",
                path = "",
            };
            var lk3 = userManage.Inseart(user);
            Assert.AreEqual(lk3, true);

            user = new Blog.Model.User()
            {
                Name = "小路",
                Email = "6245212@qq.com",
                Password = "123456",
                path = "",
            };
            var lk4 = userManage.Inseart(user);
            Assert.AreEqual(lk4, true);
            Assert.Pass();
        }
        //测试user查询
        [Test]
        public void QueryTest()
        {
           //条件查询
            var ls = userManage.Get().Where(it => it.Id == 3).ToList();
            ls.ForEach(item =>
            {
                Console.Out.WriteLine(item.Name);
            });
            Console.Out.WriteLine();
            //所有查询
            ls = userManage.Get().ToList();
            ls.ForEach(item =>
            {
                Console.Out.WriteLine(item.Name);
            });
            Console.Out.WriteLine();
            
            //模糊查询
            ls = userManage.Get().Where(it => it.Name.Contains("小")).ToList();
            ls.ForEach(item =>
            {
                Console.Out.WriteLine(item.Name);
            });
            Console.Out.WriteLine();
            //分页
            ls = userManage.Get().Skip(2).Take(3).ToList();
            ls.ForEach(item =>
            {
                Console.Out.WriteLine(item.Name);
            });
            Console.Out.WriteLine();

        }
        //测试更新
        [Test]
        public void UpdateTest()
        {

            var ls = userManage.Get().Where(it => it.Id == 3).ToList();
            ls.ForEach(item =>
            {
                item.Password = "456789";
                bool lk=  userManage.Update(item);
                Assert.AreEqual(lk, true);
            });
           
           
           
        }
        //测试删除
        [Test]
        public void DeleteTest()
        {
            Blog.Model.User user = new Blog.Model.User()
            {
               Id=5,
            };
            var lk= userManage.Delete(user);
            Assert.AreEqual(lk, true);

            user = new Blog.Model.User()
            {
                Id = 6,
            };
             lk = userManage.Delete(user,false);
            Assert.AreEqual(lk, true);
        }
    }
    
    //文章表测试
    public class ArticleTableTest
    {
        public Blog.ICRUD.ICRUD<Blog.Model.Article> articleManage;
        public Blog.Model.Article article;
        [SetUp]
        public void SetUp()
        {
            articleManage = new Blog.CRUD.ArticleManage();
        }
        //插入
        [Test]
        public void InsertTest()
        {
            article = new Blog.Model.Article()
            {
                Name = "C# 继承",
                Content = "继承是面向对象程序设计中最重要的概念之一。" +
                "继承允许我们根据一个类来定义另一个类，这使得创建和维护应用程序变得更容易。" +
                "同时也有利于重用代码和节省开发时间。当创建一个类时" +
                "，程序员不需要完全重新编写新的数据成员和成员函数，" +
                "只需要设计一个新的类，继承了已有的类的成员即可。" +
                "这个已有的类被称为的基类，这个新的类被称为派生类。" +
                "继承的思想实现了 属于（IS - A） 关系。例如，哺乳动物 " +
                "属于（IS - A） 动物，狗 属于（IS - A） 哺乳动物，因此狗" +
                " 属于（IS - A） 动物",
                UserId = 1,
        };
            var lk=articleManage.Inseart(article);
            Assert.AreEqual(lk, true);

            article = new Blog.Model.Article()
            {
                Name = "C# 简介",
                Content = "C# 是一个现代的、通用的、面向对象的编程语言，" +
                "它是由微软（Microsoft）开发的，由 Ecma 和 ISO 核准认可的。" +
                "C# 是由 Anders Hejlsberg 和他的团队在 .Net 框架开发期间开发的。" +
                "C# 是专为公共语言基础结构（CLI）设计的。CLI 由可执行代码和运行时环境组成" +
                "，允许在不同的计算机平台和体系结构上使用各种高级语言。",
                UserId = 1,
            };
             lk = articleManage.Inseart(article);
            Assert.AreEqual(lk, true);

            article = new Blog.Model.Article()
            {
                Name = "C# 继承",
                Content = "继承是面向对象程序设计中最重要的概念之一。" +
               "继承允许我们根据一个类来定义另一个类，这使得创建和维护应用程序变得更容易。" +
               "同时也有利于重用代码和节省开发时间。当创建一个类时" +
               "，程序员不需要完全重新编写新的数据成员和成员函数，" +
               "只需要设计一个新的类，继承了已有的类的成员即可。" +
               "这个已有的类被称为的基类，这个新的类被称为派生类。" +
               "继承的思想实现了 属于（IS - A） 关系。例如，哺乳动物 " +
               "属于（IS - A） 动物，狗 属于（IS - A） 哺乳动物，因此狗" +
               " 属于（IS - A） 动物",
                UserId = 1,
            };
             lk = articleManage.Inseart(article);
            Assert.AreEqual(lk, true);

            article = new Blog.Model.Article()
            {
                Name = "Net 框架",
                Content = ".Net 框架应用程序是多平台的应用程序。" +
                "框架的设计方式使它适用于下列各种语言：" +
                "C#、C++、Visual Basic、Jscript、COBOL 等等。" +
                "所有这些语言可以访问框架，彼此之间也可以互相交互。" +
                ".Net 框架由一个巨大的代码库组成，用于 C# 等客户端语言。" +
                "下面列出一些 .Net 框架的组件：",
                UserId = 1,
            };
             lk = articleManage.Inseart(article);
            Assert.AreEqual(lk, true);

            article = new Blog.Model.Article()
            {
                Name = "C# 的集成开发环境",
                Content = "微软（Microsoft）提供了下列用于 C# 编程的开发工具:/n" +
                "Visual Studio 2010(VS)Visual/n" +
                " Web Developer/n" +
                "后面两个是免费使用的，可从微软官方网址下载。" +
                "使用这些工具，您可以编写各种 C# 程序，" +
                "从简单的命令行应用程序到更复杂的应用程序。" +
                "您也可以使用基本的文本编辑器（比如 Notepad）编写 C# 源代码文件，" +
                "并使用命令行编译器（.NET 框架的一部分）编译代码为组件。" +
                "Visual C# Express 和 Visual Web Developer Express 版本是 Visual Studio " +
                "的定制版本，且具有相同的外观和感观。它们保留 Visual Studio 的大部分功能" +
                "。在本教程中，我们使用的是 Visual C# 2010 Express。",
                UserId = 1,
            };
             lk = articleManage.Inseart(article);
            Assert.AreEqual(lk, true);

            article = new Blog.Model.Article()
            {
                Name = "在 Linux 或 Mac OS 上编写 C# 程序",
                Content = "虽然.NET 框架是运行在 Windows 操作系统上，" +
                "但是也有一些运行于其它操作系统上的版本可供选择。" +
                "Mono 是.NET 框架的一个开源版本，它包含了一个 C# 编译器，" +
                "且可运行于多种操作系统上，比如各种版本的 Linux 和 Mac OS。" +
                "如需了解更多详情，请访问 Go Mono。Mono 的目的不仅仅是跨平台地运行微软.NET 应用程序，" +
                "而且也为 Linux 开发者提供了更好的开发工具。Mono 可运行在多种操作系统上" +
                "，包括 Android、BSD、iOS、Linux、OS X、Windows、Solaris 和 UNIX。",
                UserId = 1,
            };
             lk = articleManage.Inseart(article);
            Assert.AreEqual(lk, true);
            Assert.Pass();
        }
        //查询
        [Test]
        public void QueryTest()
        {
            var ls=articleManage.Get().ToList();
            ls.ForEach(item =>
            {
                Console.Out.WriteLine(item.Name);
                Console.Out.WriteLine();
            });
        }
        //更新
        [Test]
        public void UpdateTest()
        {
            var ls = articleManage.Get().Skip(2).Take(1).First();
            ls.Name = "C# jicheng";
            bool lk= articleManage.Update(ls);
            Assert.AreEqual(lk, true);
        }
        //删除
        [Test]
        public void DeleteTest()
        {
            var ls = articleManage.Get().Skip(5).Take(1).First();
            articleManage.Delete(ls);
        }
    }

    //评论表测试
    public class CommentTableTest
    {
        public  Blog.ICRUD.ICRUD<Blog.Model.Comment> commentManage;
        [SetUp]
        public void SetUp()
        {
             commentManage = new Blog.CRUD.CommentManage();
              var Db = new Blog.Model.BlogContent();
                 Db.CreateDatabase();
        }

        //插入
        [Test]
        public void InsertTest()
        {
            Blog.Model.Comment comment = new Blog.Model.Comment()
            {
                CommentatorId = "1",
                Content = "lanoasdin",
                ArticleId = 2,

            };
            bool lk=commentManage.Inseart(comment);
            Assert.AreEqual(lk, true);

             comment = new Blog.Model.Comment()
            {
                CommentatorId = "1",
                Content = "15612",
                ArticleId = 2,

            };
            lk = commentManage.Inseart(comment);
            Assert.AreEqual(lk, true);

            comment = new Blog.Model.Comment()
            {
                CommentatorId = "1",
                Content = "后倾掐粉丝",
                ArticleId = 2,

            };
             lk = commentManage.Inseart(comment);
            Assert.AreEqual(lk, true);


            comment = new Blog.Model.Comment()
            {
                CommentatorId = "1",
                Content = "oasdin",
                ArticleId = 2,

            };
            lk = commentManage.Inseart(comment);
            Assert.AreEqual(lk, true);


            comment = new Blog.Model.Comment()
            {
                CommentatorId = "1",
                Content = "链发达",
                ArticleId = 2,

            };
             lk = commentManage.Inseart(comment);
            Assert.AreEqual(lk, true);

             comment = new Blog.Model.Comment()
            {
                CommentatorId = "1",
                Content = "黄发送到",
                ArticleId = 2,

            };
            lk = commentManage.Inseart(comment);
            Assert.AreEqual(lk, true);


            comment = new Blog.Model.Comment()
            {
                CommentatorId = "1",
                Content = "lanoasdin",
                ArticleId = 2,

            };

            lk = commentManage.Inseart(comment);
            Assert.AreEqual(lk, true);


        }
        
        [Test]
        public void QueryTest()
        {
            var ls = commentManage.Get().Where(it => it.ArticleId ==2).ToList();
            ls.ForEach(item => {
                Console.Out.WriteLine(item.CommentatorId);
                Console.Out.WriteLine(item.Content);
                Console.Out.WriteLine();
            });
        }
        //更新
        [Test]
        public void UpdateTest()
        {
            var ls = commentManage.Get().Where(it => it.CommentatorId == "1").First();
            ls.Content = "测试";
            var lk=commentManage.Update(ls);
            Assert.AreEqual(lk, true);
        }
        //删除
        [Test]
        public void DeleteTest()
        {
            var ls = commentManage.Get().Where(it => it.CommentatorId == "1").OrderBy(it=>it.Id,SqlSugar.OrderByType.Desc).First();
           
            var lk = commentManage.Delete(ls);
            Assert.AreEqual(lk, true);
        }


    }

    //分类表测试
    public class CategoryTableTest
    {
        public Blog.ICRUD.ICRUD<Blog.Model.Category> categoryManage;
        public  Blog.ICRUD.ICRUD<Blog.Model.CategoryToArticle> CTAManage;
        [SetUp]
        public void Setup()
        {
         
            var Db = new Blog.Model.BlogContent();
            Db.CreateDatabase();
            categoryManage = new Blog.CRUD.CategoryManage();
             CTAManage = new Blog.CRUD.CTAManage();
        }
        //插入数据
        [Test]
        public void insertCategory()
        {
            categoryManage.Inseart(new Blog.Model.Category()
            {
                Name = "C#"
            });

            categoryManage.Inseart(new Blog.Model.Category()
            {
                Name = "nodejs"
            });

            categoryManage.Inseart(new Blog.Model.Category()
            {
                Name = "Web"
            });

            CTAManage.Inseart(new Blog.Model.CategoryToArticle()
            {
                ArticleId=1,
                CategoryId=1
            });
            CTAManage.Inseart(new Blog.Model.CategoryToArticle()
            {
                ArticleId = 1,
                CategoryId = 1
            });
            CTAManage.Inseart(new Blog.Model.CategoryToArticle()
            {
                ArticleId = 1,
                CategoryId = 3
            });
            CTAManage.Inseart(new Blog.Model.CategoryToArticle()
            {
                ArticleId = 2,
                CategoryId = 1
            });
        }

        


    }
     
}