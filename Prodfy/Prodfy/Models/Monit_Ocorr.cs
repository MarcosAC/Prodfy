using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Monit_Ocorr")]
    public class Monit_Ocorr
    {
        [PrimaryKey, AutoIncrement]
        public int idMonit_Ocorr { get; set; }
        public int disp_id { get; set; }
        public int monit_id { get; set; }
        public DateTime data { get; set; }
        public int rep { get; set; }
        public int trat { get; set; }
        public string descr { get; set; }
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
