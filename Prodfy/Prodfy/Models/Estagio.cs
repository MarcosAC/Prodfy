using SQLite;

namespace Prodfy.Models
{
    [Table("Estagio")]
    public class Estagio
    {
        [PrimaryKey, AutoIncrement]
        public int idEstagio { get; set; }
        public string estagio_id { get; set; }
        public string produto_id { get; set; }
        public string ponto_controle_id { get; set; }
        public string codigo { get; set; }
        public string titulo { get; set; }
        public string maturacao { get; set; }
        public string unidade { get; set; }
        public string matauracao_seg { get; set; }
        public string ind_alertas { get; set; }
        public string last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
