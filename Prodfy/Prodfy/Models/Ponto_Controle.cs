using SQLite;

namespace Prodfy.Models
{
    [Table("Ponto_Controle")]
    public class Ponto_Controle
    {
        [PrimaryKey, AutoIncrement]
        public int idPonto_Controle { get; set; }
        public string ponto_controle_id { get; set; }
        public string produto_id { get; set; }
        public string codigo { get; set; }
        public string titulo { get; set; }
        public string maturacao { get; set; }
        public string unidade { get; set; }
        public string maturacao_seg { get; set; }
        public string ind_alertas { get; set; }
        public string last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
