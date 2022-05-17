using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSQLite.Model
{
    [Table("ActasNacimiento")]
    public class ActaNacimiento
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
