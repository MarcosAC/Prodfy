using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Monit_Cod_Arv")]
    public class Monit_Cod_Arv
    {
        [PrimaryKey, AutoIncrement]
        public int idMonit_Cod_Arv { get; set; }
        public int monit_cod_arv_id { get; set; }

        [MaxLength(10)]
        public string codigo { get; set; }
        [MaxLength(180)]
        public string descr { get; set; }

        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
