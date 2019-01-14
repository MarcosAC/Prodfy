using SQLite;

namespace Prodfy.Models
{
    [Table("Lote")]
    public class Lote
    {
        [PrimaryKey, AutoIncrement]
        public int idLote{ get; set; }
        public string lote_id { get; set; }
        public string produto_id { get; set; }
        public string codigo { get; set; }
        public string objetivo { get; set; }
        public string cliente { get; set; }        
        public string last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
