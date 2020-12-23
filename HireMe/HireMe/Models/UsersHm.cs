using System;
using System.Collections.Generic;
using System.Text;

namespace HireMe.Models
{
    using SQLite;
    public class UsersHm
    {
        //Las propiedades siempre van en mayusculas, pero en este caso hare una excepcion
        // Estan son las propiedades de la table user_hm en la BD
        #region Properties
        [PrimaryKey,AutoIncrement]
        public int Id_userhm { get; set; }

        public string Nombre_c { get; set; }
        
        public string Apellido_user { get; set; }
        
        public string Mail_user { get; set; }
        
        public string Password_user { get; set; }

        public string Ubicacion { get; set; }

        public int Celular { get; set; } 
        #endregion


    }
}
