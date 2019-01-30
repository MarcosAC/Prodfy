using SQLite;

namespace Prodfy.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int idUser { get; set; }
        public string disp_id { get; set; }
        public string disp_num { get; set; }
        public string senha { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string empresa { get; set; }
        public int autosinc { get; set; }
        public string autosinc_time { get; set; }
        public string sinc_url { get; set; }
        public string app_key { get; set; }
        public string lang { get; set; }
        public int ind_ident { get; set; }
        public int ind_inv { get; set; }
        public int ind_per { get; set; }
        public int ind_hist { get; set; }
        public int ind_evo { get; set; }
        public int ind_mnt { get; set; }
        public int ind_exp { get; set; }
        public int ind_atv { get; set; }
        public int uso_liberado { get; set; }
        public string dht_last_sincr { get; set; }
    }
}
