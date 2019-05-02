using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Inventario")]
    public class Inventario
    {
        public int idInventario { get; set; }
        public int disp_id { get; set; }

        [MaxLength(1)]
        public string lanc { get; set; }
        [MaxLength(1)]
        public string modo { get; set; }

        public int lote_id { get; set; }
        public int ponto_controle_ori_id { get; set; }
        public int estagio_ori_id { get; set; }
        public int qualidade_ori_id { get; set; }
        public int ponto_controle_id { get; set; }
        public int estagio_id { get; set; }
        public int muda_id { get; set; }
        public DateTime data_estaq { get; set; }
        public int colab_estaq_id { get; set; }
        public DateTime data_selecao { get; set; }
        public int colab_selecao_id { get; set; }
        public int qualidade_id { get; set; }
        public int qtde { get; set; }
        public int qtde_amostragem { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_fim { get; set; }

        [MaxLength(20)]
        public string latitude { get; set; }
        [MaxLength(20)]
        public string longitude { get; set; }

        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
