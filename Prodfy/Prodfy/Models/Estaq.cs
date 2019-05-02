using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Estaq")]
    public class Estaq
    {
        [PrimaryKey, AutoIncrement]
        public int idEstaq { get; set; }
        public int lote_id { get; set; }

        [MaxLength(255)]
        public string lote { get; set; }

        public int muda_id { get; set; }

        [MaxLength(255)]
        public string muda { get; set; }

        public DateTime data_estaq { get; set; }
        public int qtde { get; set; }
        public int qualidade_id { get; set; }

        [MaxLength(255)]
        public string qualidade { get; set; }

        public int colab_estaq_id { get; set; }

        [MaxLength(255)]
        public string colab_estaq { get; set; }

        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
