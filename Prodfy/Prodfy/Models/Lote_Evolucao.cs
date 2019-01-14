using SQLite;

namespace Prodfy.Models
{
    [Table("Lote_Evolucao")]
    public class Lote_Evolucao
    {
        [PrimaryKey, AutoIncrement]
        public int idLote_Evolucao { get; set; }
        public string lote_evolucao_id { get; set; }
        public string lote_id { get; set; }
        public string ponto_controle_id { get; set; }
        public string estagio_id { get; set; }
        public string muda_id { get; set; }
        public string data_estaq { get; set; }
        public string data_selecao { get; set; }
        public string data_inicio { get; set; }
        public string data_fim { get; set; }
        public string qtde_total { get; set; }
        public string qtde { get; set; }        
        public string last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
