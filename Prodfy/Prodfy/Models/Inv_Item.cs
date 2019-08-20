using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Inv_Item")]
    public class Inv_Item
    {
        public int idInv_Item { get; set; }
        public int inv_item_id { get; set; }
        public int lote_id { get; set; }
        public int ponto_controle_id { get; set; }
        public int estagio_id { get; set; }
        public int muda_id { get; set; }
        public DateTime data_estaq { get; set; }
        public int colab_estaq_id { get; set; }
        public DateTime data_selecao { get; set; }
        public int colab_selecao_id { get; set; }
        public int qualidade_id { get; set; }
        public DateTime? data_inicio { get; set; }
        public DateTime? data_fim { get; set; }

        [MaxLength(20)]
        public string latitude { get; set; }
        [MaxLength(20)]
        public string longitude { get; set; }

        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
