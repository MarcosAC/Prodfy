using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Monit_Parcela")]
    public class Monit_Parcela
    {
        [PrimaryKey, AutoIncrement]
        public int idMonit_Parcela { get; set; }
        public int monit_parcela_id { get; set; }
        public int monit_id { get; set; }
        public int parcela { get; set; }
        public int muda_id { get; set; }
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
