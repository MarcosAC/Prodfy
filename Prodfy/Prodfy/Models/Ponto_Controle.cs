using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Ponto_Controle")]
    public class Ponto_Controle
    {
        [PrimaryKey, AutoIncrement]
        public int idPonto_Controle { get; set; }
        public int ponto_controle_id { get; set; }
        public int produto_id { get; set; }
        public string codigo { get; set; }
        public string titulo { get; set; }
        public int maturacao { get; set; }
        public string unidade { get; set; }
        public int maturacao_seg { get; set; }
        public int ind_alertas { get; set; }
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
