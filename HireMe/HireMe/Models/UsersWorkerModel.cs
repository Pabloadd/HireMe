using System;
using System.Collections.Generic;
using System.Text;

namespace HireMe.Models
{
    public class UsersWorkerModel 
    {
        public string Nombre_c { get; set; }
        public string Apellido_user { get; set; }

        public string Ubicacion { get; set; }

        public string Mail_user { get; set; }

        public int Celular { get; set; }

        public string profesion { get; set; }
    }
    
/*
 "Select UsersHm.Nombre_c, UsersHm.Apellido_user, UsersWorkers.profesion " +
                "from UsersHm, UsersWorkers " +
                "Where UsersHm.Id_userhm = UsersWorkers.Id_userhm"
 */
}
