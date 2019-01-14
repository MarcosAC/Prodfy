using SQLite;

namespace Prodfy.Models
{
    [Table("Estaq")]
    public class Estaq
    {
        [PrimaryKey, AutoIncrement]
        public int idEstaq { get; set; }
        public string lote_inventario_id { get; set; }
        public string lote_id { get; set; }
        public string lote { get; set; }
        public string muda_id { get; set; }
        public string muda { get; set; }
        public string data_estaq { get; set; }
        public string qtde { get; set; }
        public string qualidade_id { get; set; }
        public string qualidade { get; set; }
        public string colab_estaq_id { get; set; }
        public string colab_estaq { get; set; }
        public string last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
