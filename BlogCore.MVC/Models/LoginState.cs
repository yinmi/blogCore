using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCore.MVC.Models
{
    public class LoginState
    {
        //code 只有两种状态，0成功，1，失败
        public int code { get; set; }
        //错误信息
        public string message { get; set; }
    }
}
