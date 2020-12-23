using System;
using System.Collections.Generic;
using System.Text;

namespace HireMe.Models
{
    using SQLite;
    using SQLiteNetExtensions;
    using SQLiteNetExtensions.Attributes;

    public class UsersWorkers
    {
        [PrimaryKey,AutoIncrement]
        public int IdUserWork { get; set; }
        public string profesion { get; set; }
        [ForeignKey(typeof(UsersHm))]
        public int Id_userhm { get; set; }
        
        [ManyToOne]
        public UsersHm usershm { get; set; }
    }
}
