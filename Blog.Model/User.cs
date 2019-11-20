using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class User :Base
    {
        public string Name { get; set; }

        public string Email { get; set;}
        
        public string Password { get; set; }
        
        public string path { get; set; }
    }
}
