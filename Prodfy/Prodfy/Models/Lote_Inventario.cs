using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Lote_Inventario")]
    public class Lote_Inventario
    {
        [PrimaryKey, AutoIncrement]
        public int idLote_Inventario { get; set; }
        public int lote_inventario_id { get; set; }
        public int lote_id { get; set; }
        public int muda_id { get; set; }
        public DateTime data_estaq { get; set; }
        public DateTime data_selecao { get; set; }
        public int qtde { get; set; }
        public int colab_estaq_id { get; set; }
        public string colab_estaq { get; set; }
        public int colab_selecao_id { get; set; }
        public string colab_selecao { get; set; }
        public int qualidade_id { get; set; }
        public string qualidade { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
