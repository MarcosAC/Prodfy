using SQLite;

namespace Prodfy.Models
{
    [Table("Lista_Atv")]
    public class Lista_Atv
    {
        [PrimaryKey, AutoIncrement]
        public int idLista_Atv { get; set; }
        public string lista_atv_id { get; set; }
        public string codigo { get; set; }
        public string titulo { get; set; }
        public string drescr { get; set; }
        public int media_exec { get; set; }        
        public int definicao { get; set; }
        public string last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
