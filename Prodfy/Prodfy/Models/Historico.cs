using SQLite;

namespace Prodfy.Models
{
    [Table("Historico")]
    public class Historico
    {
        [PrimaryKey, AutoIncrement]
        public int idHistorico { get; set; }
        public string disp_id { get; set; }
        public string lote_id { get; set; }
        public string data { get; set; }
        public string titulo { get; set; }
        public string texto { get; set; }
        public string last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
