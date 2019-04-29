using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Produto")]
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int idProduto { get; set; }
        public int produto_id { get; set; }
        public string titulo { get; set; }
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
