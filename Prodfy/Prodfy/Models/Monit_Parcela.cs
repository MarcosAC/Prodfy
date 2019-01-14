using SQLite;

namespace Prodfy.Models
{
    [Table("Monit_Parcela")]
    public class Monit_Parcela
    {
        [PrimaryKey, AutoIncrement]
        public int idMonit_Parcela { get; set; }
        public string monit_parcela_id { get; set; }
        public string monit_id { get; set; }
        public string parcela { get; set; }
        public string muda_id { get; set; }
        public string last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
