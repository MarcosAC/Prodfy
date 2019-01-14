using SQLite;

namespace Prodfy.Models
{
    [Table("Monit_Ocorr")]
    public class Monit_Ocorr
    {
        [PrimaryKey, AutoIncrement]
        public int idMonit_Ocorr { get; set; }
        public string disp_id { get; set; }
        public string monit_id { get; set; }
        public string data { get; set; }
        public string rep { get; set; }
        public string trat { get; set; }
        public string descr { get; set; }
        public string last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
