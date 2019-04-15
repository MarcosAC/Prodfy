using SQLite;
using System.Collections.Generic;

namespace Prodfy.Models
{
    [Table("Produto")]
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int idProduto { get; set; }
        public string produto_id { get; set; }
        public string titulo { get; set; }
        public string last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
