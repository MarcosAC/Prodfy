using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Exped_Dest")]
    public class Exped_Dest
    {
        [PrimaryKey, AutoIncrement]
        public int idExped_Dest { get; set; }
        public int exped_dest_id { get; set; }

        [MaxLength(180)]
        public string titulo { get; set; }
        [MaxLength(255)]
        public string descr { get; set; }
        
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
