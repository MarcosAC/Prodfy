using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Movimentacao")]
    public class Movimentacao
    {
        public int idMovimentacao { get; set; }
        public int disp_id { get; set; }
        public int inv_item_id { get; set; }

        [MaxLength(1)]
        public string lanc { get; set; }

        public int lote_id { get; set; }
        public int ponto_control_ori_id { get; set; }
        public int estagio_ori_id { get; set; }
        public int muda_ori_id { get; set; }
        public int qualidade_ori_id { get; set; }
        public DateTime data_estaq_ori { get; set; }
        public int colab_estaq_ori_id { get; set; }
        public DateTime data_selecao_ori { get; set; }
        public int colab_selecao_ori_id { get; set; }
        public int ponto_controle_dst_id { get; set; }
        public int estagio_dst_id { get; set; }
        public int qtde_amostragem { get; set; }
        public int qtde { get; set; }
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
