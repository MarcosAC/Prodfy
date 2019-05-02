using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Perda_Motivo")]
    public class Perda_Motivo
    {
        [PrimaryKey, AutoIncrement]
        public int idPerda_Motivo { get; set; }
        public int perda_motivo_id { get; set; }

        [MaxLength(45)]
        public string motivo { get; set; }        

        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
