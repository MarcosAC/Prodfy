using SQLite;

namespace Prodfy.Models
{
    [Table("Perda_Motivo")]
    public class Perda_Motivo
    {
        [PrimaryKey, AutoIncrement]
        public int idPerda_Motivo { get; set; }
        public string perda_motivo_id { get; set; }
        public string motivo { get; set; }        
        public string last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
