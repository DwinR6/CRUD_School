using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CRUD_School.Model
{
    public class AlumnosModel
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string FechaNacimiento { get; set; }
        public string Grado { get; set; }
        public string Seccion { get; set; }
        public int Edad { get; set; }
        public int NumeroMovil { get; set; }


    }
}
