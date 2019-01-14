using SQLite;

namespace Prodfy.Models
{
    [Table("Perda")]
    public class Perda
    {
        [PrimaryKey, AutoIncrement]
        public int idPerda { get; set; }
        public string disp_id { get; set; }
        public string lote_id { get; set; }
        public string muda_id { get; set; }
        public string produto_id { get; set; }
        public string ponto_controle_id { get; set; }
        public string estagio_id { get; set; }
        public string motivo_id { get; set; }
        public string data { get; set; }
        public string qtde { get; set; }
        public string last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
