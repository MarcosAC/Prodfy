using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Estaq")]
    public class Estaq
    {
        [PrimaryKey, AutoIncrement]
        public int idEstaq { get; set; }
        public int lote_inventario_id { get; set; }
        public int lote_id { get; set; }
        public string lote { get; set; }
        public int muda_id { get; set; }
        public string muda { get; set; }
        public DateTime data_estaq { get; set; }
        public int qtde { get; set; }
        public int qualidade_id { get; set; }
        public string qualidade { get; set; }
        public int colab_estaq_id { get; set; }
        public DateTime colab_estaq { get; set; }
        public string last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
