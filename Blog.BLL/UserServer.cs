using System;
using System.Collections.Generic;
using System.Text;
using Blog.DateToView;

namespace Blog.BLL
{
    public class UserServer : IUserServer
    {
        private ICRUD.ICRUD<Model.User> UserManage;
        public  UserServer()
        {
            UserManage = new CRUD.UserManage();
        }

        //根据id获取
        public UserDate GetUser(int Id)
        {
            return UserManage.Get().
                Where(item => item.Id == Id).
                Select(item=>new UserDate() {
                    UserName=item.Name,
                    Email=item.Email,
                    Password=item.Password,
                }).
                First();
        }

        //根据email判断书否存在
        public bool AnyUser(string email)
        {
            return UserManage.Get().Any(item => item.Email == email);
        }

        //根据email获取user
        public UserDate GetUser(string email)
        {
            return UserManage.Get().
                Where(item => item.Email == email).
                Select(item=>new UserDate() {
                     Email=item.Email,
                     Password=item.Password,
                     UserId=item.Id,
                     UserName=item.Name,
                }).First();
        }

        //注册用户
        public bool AddUser(string name,string email,string password)
        {
            return UserManage.Inseart(new Model.User() {
                Name = name,
                Email=email,
                Password=password
            });
        }
    }
}
