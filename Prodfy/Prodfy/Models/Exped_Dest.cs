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
        public string titulo { get; set; }
        public string descr { get; set; }        
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
