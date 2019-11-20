using NUnit.Framework;
using System;
using System.Linq;


namespace Tests
{
    //�û������
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
       //����user����
        [Test]
        public void InsertTest()
        {
             
            Blog.Model.User user = new Blog.Model.User()
            {
                Name = "С��",
                Email="6212@qq.com",
                Password="123456",
                path="",
            };
            var lk= userManage.Inseart(user);
            Assert.AreEqual(lk, true);

            user = new Blog.Model.User()
            {
                Name = "С��",
                Email = "6252@qq.com",
                Password = "123456",
                path = "",
            };
            var lk2 = userManage.Inseart(user);
            Assert.AreEqual(lk2, true);

            user = new Blog.Model.User()
            {
                Name = "С��",
                Email = "621152@qq.com",
                Password = "123456",
                path = "",
            };
            var lk3 = userManage.Inseart(user);
            Assert.AreEqual(lk3, true);

            user = new Blog.Model.User()
            {
                Name = "С·",
                Email = "6245212@qq.com",
                Password = "123456",
                path = "",
            };
            var lk4 = userManage.Inseart(user);
            Assert.AreEqual(lk4, true);
            Assert.Pass();
        }
        //����user��ѯ
        [Test]
        public void QueryTest()
        {
           //������ѯ
            var ls = userManage.Get().Where(it => it.Id == 3).ToList();
            ls.ForEach(item =>
            {
                Console.Out.WriteLine(item.Name);
            });
            Console.Out.WriteLine();
            //���в�ѯ
            ls = userManage.Get().ToList();
            ls.ForEach(item =>
            {
                Console.Out.WriteLine(item.Name);
            });
            Console.Out.WriteLine();
            
            //ģ����ѯ
            ls = userManage.Get().Where(it => it.Name.Contains("С")).ToList();
            ls.ForEach(item =>
            {
                Console.Out.WriteLine(item.Name);
            });
            Console.Out.WriteLine();
            //��ҳ
            ls = userManage.Get().Skip(2).Take(3).ToList();
            ls.ForEach(item =>
            {
                Console.Out.WriteLine(item.Name);
            });
            Console.Out.WriteLine();

        }
        //���Ը���
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
        //����ɾ��
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
    
    //���±����
    public class ArticleTableTest
    {
        public Blog.ICRUD.ICRUD<Blog.Model.Article> articleManage;
        public Blog.Model.Article article;
        [SetUp]
        public void SetUp()
        {
            articleManage = new Blog.CRUD.ArticleManage();
        }
        //����
        [Test]
        public void InsertTest()
        {
            article = new Blog.Model.Article()
            {
                Name = "C# �̳�",
                Content = "�̳����������������������Ҫ�ĸ���֮һ��" +
                "�̳��������Ǹ���һ������������һ���࣬��ʹ�ô�����ά��Ӧ�ó����ø����ס�" +
                "ͬʱҲ���������ô���ͽ�ʡ����ʱ�䡣������һ����ʱ" +
                "������Ա����Ҫ��ȫ���±�д�µ����ݳ�Ա�ͳ�Ա������" +
                "ֻ��Ҫ���һ���µ��࣬�̳������е���ĳ�Ա���ɡ�" +
                "������е��౻��Ϊ�Ļ��࣬����µ��౻��Ϊ�����ࡣ" +
                "�̳е�˼��ʵ���� ���ڣ�IS - A�� ��ϵ�����磬���鶯�� " +
                "���ڣ�IS - A�� ����� ���ڣ�IS - A�� ���鶯���˹�" +
                " ���ڣ�IS - A�� ����",
                UserId = 1,
        };
            var lk=articleManage.Inseart(article);
            Assert.AreEqual(lk, true);

            article = new Blog.Model.Article()
            {
                Name = "C# ���",
                Content = "C# ��һ���ִ��ġ�ͨ�õġ��������ı�����ԣ�" +
                "������΢��Microsoft�������ģ��� Ecma �� ISO ��׼�Ͽɵġ�" +
                "C# ���� Anders Hejlsberg �������Ŷ��� .Net ��ܿ����ڼ俪���ġ�" +
                "C# ��רΪ�������Ի����ṹ��CLI����Ƶġ�CLI �ɿ�ִ�д��������ʱ�������" +
                "�������ڲ�ͬ�ļ����ƽ̨����ϵ�ṹ��ʹ�ø��ָ߼����ԡ�",
                UserId = 1,
            };
             lk = articleManage.Inseart(article);
            Assert.AreEqual(lk, true);

            article = new Blog.Model.Article()
            {
                Name = "C# �̳�",
                Content = "�̳����������������������Ҫ�ĸ���֮һ��" +
               "�̳��������Ǹ���һ������������һ���࣬��ʹ�ô�����ά��Ӧ�ó����ø����ס�" +
               "ͬʱҲ���������ô���ͽ�ʡ����ʱ�䡣������һ����ʱ" +
               "������Ա����Ҫ��ȫ���±�д�µ����ݳ�Ա�ͳ�Ա������" +
               "ֻ��Ҫ���һ���µ��࣬�̳������е���ĳ�Ա���ɡ�" +
               "������е��౻��Ϊ�Ļ��࣬����µ��౻��Ϊ�����ࡣ" +
               "�̳е�˼��ʵ���� ���ڣ�IS - A�� ��ϵ�����磬���鶯�� " +
               "���ڣ�IS - A�� ����� ���ڣ�IS - A�� ���鶯���˹�" +
               " ���ڣ�IS - A�� ����",
                UserId = 1,
            };
             lk = articleManage.Inseart(article);
            Assert.AreEqual(lk, true);

            article = new Blog.Model.Article()
            {
                Name = "Net ���",
                Content = ".Net ���Ӧ�ó����Ƕ�ƽ̨��Ӧ�ó���" +
                "��ܵ���Ʒ�ʽʹ�����������и������ԣ�" +
                "C#��C++��Visual Basic��Jscript��COBOL �ȵȡ�" +
                "������Щ���Կ��Է��ʿ�ܣ��˴�֮��Ҳ���Ի��ཻ����" +
                ".Net �����һ���޴�Ĵ������ɣ����� C# �ȿͻ������ԡ�" +
                "�����г�һЩ .Net ��ܵ������",
                UserId = 1,
            };
             lk = articleManage.Inseart(article);
            Assert.AreEqual(lk, true);

            article = new Blog.Model.Article()
            {
                Name = "C# �ļ��ɿ�������",
                Content = "΢��Microsoft���ṩ���������� C# ��̵Ŀ�������:/n" +
                "Visual Studio 2010(VS)Visual/n" +
                " Web Developer/n" +
                "�������������ʹ�õģ��ɴ�΢��ٷ���ַ���ء�" +
                "ʹ����Щ���ߣ������Ա�д���� C# ����" +
                "�Ӽ򵥵�������Ӧ�ó��򵽸����ӵ�Ӧ�ó���" +
                "��Ҳ����ʹ�û������ı��༭�������� Notepad����д C# Դ�����ļ���" +
                "��ʹ�������б�������.NET ��ܵ�һ���֣��������Ϊ�����" +
                "Visual C# Express �� Visual Web Developer Express �汾�� Visual Studio " +
                "�Ķ��ư汾���Ҿ�����ͬ����ۺ͸йۡ����Ǳ��� Visual Studio �Ĵ󲿷ֹ���" +
                "���ڱ��̳��У�����ʹ�õ��� Visual C# 2010 Express��",
                UserId = 1,
            };
             lk = articleManage.Inseart(article);
            Assert.AreEqual(lk, true);

            article = new Blog.Model.Article()
            {
                Name = "�� Linux �� Mac OS �ϱ�д C# ����",
                Content = "��Ȼ.NET ����������� Windows ����ϵͳ�ϣ�" +
                "����Ҳ��һЩ��������������ϵͳ�ϵİ汾�ɹ�ѡ��" +
                "Mono ��.NET ��ܵ�һ����Դ�汾����������һ�� C# ��������" +
                "�ҿ������ڶ��ֲ���ϵͳ�ϣ�������ְ汾�� Linux �� Mac OS��" +
                "�����˽�������飬����� Go Mono��Mono ��Ŀ�Ĳ������ǿ�ƽ̨������΢��.NET Ӧ�ó���" +
                "����ҲΪ Linux �������ṩ�˸��õĿ������ߡ�Mono �������ڶ��ֲ���ϵͳ��" +
                "������ Android��BSD��iOS��Linux��OS X��Windows��Solaris �� UNIX��",
                UserId = 1,
            };
             lk = articleManage.Inseart(article);
            Assert.AreEqual(lk, true);
            Assert.Pass();
        }
        //��ѯ
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
        //����
        [Test]
        public void UpdateTest()
        {
            var ls = articleManage.Get().Skip(2).Take(1).First();
            ls.Name = "C# jicheng";
            bool lk= articleManage.Update(ls);
            Assert.AreEqual(lk, true);
        }
        //ɾ��
        [Test]
        public void DeleteTest()
        {
            var ls = articleManage.Get().Skip(5).Take(1).First();
            articleManage.Delete(ls);
        }
    }

    //���۱����
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

        //����
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
                Content = "��������˿",
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
                Content = "������",
                ArticleId = 2,

            };
             lk = commentManage.Inseart(comment);
            Assert.AreEqual(lk, true);

             comment = new Blog.Model.Comment()
            {
                CommentatorId = "1",
                Content = "�Ʒ��͵�",
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
        //����
        [Test]
        public void UpdateTest()
        {
            var ls = commentManage.Get().Where(it => it.CommentatorId == "1").First();
            ls.Content = "����";
            var lk=commentManage.Update(ls);
            Assert.AreEqual(lk, true);
        }
        //ɾ��
        [Test]
        public void DeleteTest()
        {
            var ls = commentManage.Get().Where(it => it.CommentatorId == "1").OrderBy(it=>it.Id,SqlSugar.OrderByType.Desc).First();
           
            var lk = commentManage.Delete(ls);
            Assert.AreEqual(lk, true);
        }


    }

    //��������
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
        //��������
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