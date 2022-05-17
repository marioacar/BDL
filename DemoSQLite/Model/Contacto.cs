using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSQLite.Model
{
    [Table("Contactos")]
    public class Contacto
    {
        [PrimaryKey,AutoIncrement]
      public int Id { get; set; }
      public string Avatar { get; set; }
      public string Nombre { get; set; }
      public string ApellidoPaterno { get; set; }
      public string ApellidoMaterno { get; set; }
      public string Email { get; set; }

        [ForeignKey(typeof(ActaNacimiento))]
        public int FKActaNacimientoId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public ActaNacimiento ActaNacimiento { get; set; }
}

}
