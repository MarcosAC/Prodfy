using SQLite;

namespace Prodfy.Models
{
    [Table("Lote_Inventario")]
    public class Lote_Inventario
    {
        [PrimaryKey, AutoIncrement]
        public int idLote_Inventario { get; set; }
        public string lote_inventario_id { get; set; }
        public string lote_id { get; set; }
        public string muda_id { get; set; }
        public string data_estaq { get; set; }
        public string data_selecao { get; set; }
        public string qtde { get; set; }
        public string colab_estaq_id { get; set; }
        public string colab_estaq { get; set; }
        public string colab_selecao_id { get; set; }
        public string colab_selecao { get; set; }
        public string qualidade_id { get; set; }
        public string qualidade { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
