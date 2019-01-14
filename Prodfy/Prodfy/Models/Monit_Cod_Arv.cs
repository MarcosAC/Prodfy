using SQLite;

namespace Prodfy.Models
{
    [Table("Monit_Cod_Arv")]
    public class Monit_Cod_Arv
    {
        [PrimaryKey, AutoIncrement]
        public int idMonit_Cod_Arv { get; set; }
        public string monit_cod_arv_id { get; set; }
        public string codigo { get; set; }
        public string descr { get; set; }
        public string last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
