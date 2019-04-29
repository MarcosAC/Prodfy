using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Objetivo")]
    public class Objetivo
    {
        [PrimaryKey, AutoIncrement]
        public int idObjetivo { get; set; }
        public int objetivo_id { get; set; }
        public string titulo { get; set; }
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
