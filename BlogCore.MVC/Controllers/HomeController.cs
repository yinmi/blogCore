using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BlogCore.MVC.Models;
using Blog.BLL;
using Blog.DateToView;

namespace BlogCore.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            IArticleServer articleServer = new ArticleServer();

            IUserServer userServer = new UserServer();
            List<ArticleDate> Article = articleServer.GetLatestArticleTitle();

            Article.ForEach(item => {
                UserDate userDate = userServer.GetUser(item.UserId);
                item.UserName = userDate.UserName;
            });

            return View(Article);
        }
        public IActionResult Article()
        {
            string ArticleId = Request.Query["ArticleId"];
            IArticleServer articleServer = new ArticleServer();

            ArticleDate articleDate = articleServer.GetArticle(int.Parse(ArticleId));
            
            return View(articleDate);
        }
        //登入
       
        public IActionResult Login()
        {
            UserDate user = new UserDate();
            user.Email = Request.Form["email"];
            user.Password = Request.Form["password"];
            LoginState loginState = new LoginState();
            IUserServer userServer = new UserServer();
            if(userServer.AnyUser(user.Email))
            {
                UserDate userDate = userServer.GetUser(user.Email);
                if(user.Password==userDate.Password)
                {
                    loginState.code = 0;
                    loginState.message = "success";

                    HttpContext.Response.Cookies.Append("email", user.Email);
                    HttpContext.Response.Cookies.Append("password", user.Password);
                    HttpContext.Session.SetString("email", user.Email);
                    HttpContext.Session.SetString("password", user.Password);

                }else
                {
                    loginState.code = 1;
                    loginState.message = "password error";
                }
            }else
            {
                loginState.code = 1;
                loginState.message = "no user";
            }
            
            return Json(loginState);
        }
        //注册
       
        public IActionResult Register()
        {
            LoginState loginState = new LoginState();
            IUserServer userServer = new UserServer();
            UserDate user = new UserDate();
            user.Email = HttpContext.Request.Form["email"];
            user.UserName = HttpContext.Request.Form["username"];
            user.Password = HttpContext.Request.Form["password"];
            string Repassword = HttpContext.Request.Form["repassword"];
            if(user.Password==Repassword)
            {
                if(!userServer.AnyUser(user.Email))
                {
                    userServer.AddUser(user.UserName, user.Email, user.Password);

                    loginState.code = 0;
                    loginState.message = "success";
                }else
                {
                    loginState.code = 1;
                    loginState.message = "用户已注册";
                }
            }else
            {
                loginState.code = 1;
                loginState.message = "两次输入密码不一致";
            }

            return Json(loginState);
        }
        //登出
       
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("email");
            HttpContext.Response.Cookies.Delete("password");
            HttpContext.Session.Remove("email");
            HttpContext.Session.Remove("password");

            LoginState loginState = new LoginState();
            loginState.code = 0;
            loginState.message = "success";
            return Json(loginState);
        }
     
    }
}
