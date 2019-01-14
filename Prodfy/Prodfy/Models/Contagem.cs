using SQLite;

namespace Prodfy.Models
{
    [Table("Contagem")]
    public class Contagem
    {
        [PrimaryKey, AutoIncrement]
        public int idContagem { get; set; }
        public string disp_id { get; set; }
        public string lote_id { get; set; }
        public string muda_id { get; set; }
        public string qtde { get; set; }
        public string proc { get; set; }
        public string ponto_controle_id { get; set; }
        public string estagio_id { get; set; }
        public string data_selecao { get; set; }
        public string data_inicio { get; set; }
        public string data_fim { get; set; }
        public string data_estaq { get; set; }
        public string colab_estaq_id { get; set; }
        public string colab_sel_id { get; set; }
        public string qualidade_id { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
