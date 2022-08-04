using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XF_GencoVideo.Models
{
    public abstract class BaseModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


    }
}
