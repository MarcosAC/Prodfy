using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Historico")]
    public class Historico
    {
        [PrimaryKey, AutoIncrement]
        public int idHistorico { get; set; }
        public int disp_id { get; set; }
        public int lote_id { get; set; }
        public DateTime data { get; set; }

        [MaxLength(180)]
        public string titulo { get; set; }
        [MaxLength(2000)]
        public string texto { get; set; }

        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
