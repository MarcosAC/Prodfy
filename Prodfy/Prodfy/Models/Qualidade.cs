using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Qualidade")]
    public class Qualidade
    {
        [PrimaryKey, AutoIncrement]
        public int idQualidade { get; set; }
        public int qualidade_id { get; set; }
        public string codigo { get; set; }
        public string titulo { get; set; }
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
