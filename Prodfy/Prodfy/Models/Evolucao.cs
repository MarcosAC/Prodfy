using SQLite;

namespace Prodfy.Models
{
    [Table("Evolucao")]
    public class Evolucao
    {
        [PrimaryKey, AutoIncrement]
        public int idEvolucao { get; set; }
        public string data { get; set; }
        public string disp_id { get; set; }
        public string lote_id { get; set; }
        public string ponto_controle_id { get; set; }
        public string estagio_id { get; set; }
        public string muda_id { get; set; }
        public string ind_muda_todas { get; set; }
        public string data_estaq { get; set; }
        public string qtde_total { get; set; }
        public string qtde { get; set; }
        public string data_selecao { get; set; }
        public string data_inicio { get; set; }
        public string data_fim { get; set; }
        public string last_update { get; set; }
        public string ind_sinc { get; set; }
    }
}
