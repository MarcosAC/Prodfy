using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Monit_Med")]
    public class Monit_Med
    {
        [PrimaryKey, AutoIncrement]
        public int idMonit_Med { get; set; }
        public int disp_id { get; set; }
        public int monit_id { get; set; }
        public DateTime data { get; set; }
        public int parcela { get; set; }

        [MaxLength(10)]
        public string cod_arv { get; set; }

        public decimal altura { get; set; }
        public decimal cap { get; set; }
        public decimal dap { get; set; }
        public int falha_diag { get; set; }
        public int falha_lat { get; set; }
        public int falha_col { get; set; }

        [MaxLength(255)]
        public string obs { get; set; }

        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
