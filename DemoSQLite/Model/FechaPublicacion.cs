using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSQLite.Model
{
   [Table("FechasPublicacion")]
   public class FechaPublicacion
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Publicacion { get; set; }
    }
}
