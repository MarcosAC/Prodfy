using SQLite;

namespace Prodfy.Models
{
    [Table("Objetivo")]
    public class Objetivo
    {
        [PrimaryKey, AutoIncrement]
        public int idObjetivo { get; set; }
        public string objetivo_id { get; set; }
        public string titulo { get; set; }
        public string last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
