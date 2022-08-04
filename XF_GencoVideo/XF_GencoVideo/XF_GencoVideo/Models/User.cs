using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace XF_GencoVideo.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public string UserId { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
