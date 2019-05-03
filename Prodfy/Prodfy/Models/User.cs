using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int idUser { get; set; }
        public int disp_id { get; set; }
        public int disp_num { get; set; }

        [MaxLength(30)]
        public string senha { get; set; }
        [MaxLength(45)]
        public string nome { get; set; }
        [MaxLength(45)]
        public string sobrenome { get; set; }
        [MaxLength(150)]
        public string empresa { get; set; }

        public int? autosinc { get; set; }
        public int? autosinc_time { get; set; }

        [MaxLength(255)]
        public string sinc_url { get; set; }
        [MaxLength(80)]
        public string app_key { get; set; }
        [MaxLength(5)]
        public string lang { get; set; }

        public int? ind_ident { get; set; }
        public int? ind_inv { get; set; }
        public int? ind_mov { get; set; }
        public int? ind_per { get; set; }
        public int? ind_hist { get; set; }        
        public int? ind_mnt { get; set; }
        public int? ind_exp { get; set; }
        public int? ind_atv { get; set; }
        public int? uso_liberado { get; set; }
        public DateTime dth_last_sincr { get; set; }
        public int? sinc_stat { get; set; }
        public string sinc_msg { get; set; }
    }
}
