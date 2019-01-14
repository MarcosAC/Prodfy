using SQLite;

namespace Prodfy.Models
{
    [Table("Monit_Med")]
    public class Monit_Med
    {
        [PrimaryKey, AutoIncrement]
        public int idMonit_Med { get; set; }
        public string disp_id { get; set; }
        public string monit_id { get; set; }
        public string data { get; set; }
        public string parcela { get; set; }
        public string cod_arv { get; set; }
        public string altura { get; set; }
        public string cap { get; set; }
        public string dap { get; set; }
        public string falha_diag { get; set; }
        public string falha_lat { get; set; }
        public string falha_col { get; set; }
        public string obs { get; set; }
        public string last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
