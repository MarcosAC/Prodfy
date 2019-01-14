using SQLite;

namespace Prodfy.Models
{
    [Table("Monit")]
    public class Monit
    {
        [PrimaryKey, AutoIncrement]
        public int idMonit { get; set; }
        public string monit_id { get; set; }
        public string codigo { get; set; }
        public string produto_id { get; set; }
        public string objetivo_id { get; set; }
        public string data_plantio { get; set; }
        public string esp_linha { get; set; }
        public string esp_plantas { get; set; }
        public string projeto { get; set; }
        public string talhao { get; set; }
        public string num_trat { get; set; }
        public string num_rep { get; set; }
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
        public string last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
