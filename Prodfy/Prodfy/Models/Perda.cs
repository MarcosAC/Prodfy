using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Perda")]
    public class Perda
    {
        [PrimaryKey, AutoIncrement]
        public int idPerda { get; set; }
        public int disp_id { get; set; }
        public int lote_id { get; set; }
        public int muda_id { get; set; }
        public int produto_id { get; set; }
        public int ponto_controle_id { get; set; }
        public int estagio_id { get; set; }
        public int motivo_id { get; set; }
        public DateTime data { get; set; }
        public int qtde { get; set; }
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
