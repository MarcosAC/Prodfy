using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Estagio")]
    public class Estagio
    {
        [PrimaryKey, AutoIncrement]
        public int idEstagio { get; set; }
        public int estagio_id { get; set; }
        public int produto_id { get; set; }
        public int ponto_controle_id { get; set; }
        public string codigo { get; set; }
        public string titulo { get; set; }
        public int maturacao { get; set; }
        public string unidade { get; set; }
        public int matauracao_seg { get; set; }
        public int ind_alertas { get; set; }
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
