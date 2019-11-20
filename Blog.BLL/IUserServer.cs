using System;

namespace Blog.BLL
{
    public  interface IUserServer
    {
        //根据id获取用户
        DateToView.UserDate GetUser(int Id);

        bool AnyUser(string email);

        DateToView.UserDate GetUser(string email);

        bool AddUser(string name, string email, string password);

    }
}
