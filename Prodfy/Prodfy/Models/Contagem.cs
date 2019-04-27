using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Contagem")]
    public class Contagem
    {
        [PrimaryKey, AutoIncrement]
        public int idContagem { get; set; }
        public int disp_id { get; set; }
        public int lote_id { get; set; }
        public int muda_id { get; set; }
        public int qtde { get; set; }
        public int proc { get; set; }
        public int ponto_controle_id { get; set; }
        public int estagio_id { get; set; }
        public DateTime data_selecao { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_fim { get; set; }
        public DateTime data_estaq { get; set; }
        public int colab_estaq_id { get; set; }
        public int colab_sel_id { get; set; }
        public int qualidade_id { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
