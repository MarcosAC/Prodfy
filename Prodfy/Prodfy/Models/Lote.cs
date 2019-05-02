using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Lote")]
    public class Lote
    {
        [PrimaryKey, AutoIncrement]
        public int idLote{ get; set; }
        public int lote_id { get; set; }
        public int produto_id { get; set; }

        [MaxLength(60)]
        public string codigo { get; set; }
        [MaxLength(80)]
        public string objetivo { get; set; }
        [MaxLength(30)]
        public string cliente { get; set; }
        
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
