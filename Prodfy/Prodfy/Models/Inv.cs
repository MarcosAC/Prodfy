using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Inv")]
    public class Inv
    {
        [PrimaryKey, AutoIncrement]
        public int idInv { get; set; }
        public int inv_id { get; set; }
        public int inv_item_id { get; set; }
        public int qtde { get; set; }
        public int qtde_amostragem { get; set; }
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
