using System;
using System.Collections.Generic;
using System.Text;

namespace HireMe.Models
{
    using SQLite;
    public class RegistroBusqueda
    {
        [PrimaryKey,AutoIncrement]
        public int IdSearch { get; set; }
        public string Profesion { get; set; }
        public string Ubicacion { get; set; }
        public string Fecha { get; set; }

    }
}
