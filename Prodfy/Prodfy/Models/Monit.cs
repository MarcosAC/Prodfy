using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Monit")]
    public class Monit
    {
        [PrimaryKey, AutoIncrement]
        public int idMonit { get; set; }
        public int monit_id { get; set; }
        public string codigo { get; set; }
        public int produto_id { get; set; }
        public int objetivo_id { get; set; }
        public DateTime data_plantio { get; set; }
        public decimal esp_linha { get; set; }
        public decimal esp_plantas { get; set; }
        public string projeto { get; set; }
        public string talhao { get; set; }
        public int num_trat { get; set; }
        public int num_rep { get; set; }
        public string pi_lat_g { get; set; }
        public string pi_lat_m { get; set; }
        public string pi_lat_s { get; set; }
        public string pi_lat_d { get; set; }
        public string pi_lat { get; set; }
        public string pi_lng_g { get; set; }
        public string pi_lng_m { get; set; }
        public string pi_lng_s { get; set; }
        public string pi_lng_d { get; set; }
        public string pi_lng { get; set; }        
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
