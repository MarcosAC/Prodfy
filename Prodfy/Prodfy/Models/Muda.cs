using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Muda")]
    public class Muda
    {
        [PrimaryKey, AutoIncrement]
        public int idMuda { get; set; }
        public int muda_id{ get; set; }

        [MaxLength(80)]
        public string nome_interno { get; set; }
        [MaxLength(80)]
        public string nome { get; set; }
        [MaxLength(80)]
        public string especie_nome_comum { get; set; }
        [MaxLength(80)]
        public string especie_nome_especie { get; set; }
        [MaxLength(80)]
        public string especie_nome_cientifico { get; set; }
        [MaxLength(20)]
        public string origem { get; set; }
        [MaxLength(20)]
        public string viveiro { get; set; }
        [MaxLength(10)]
        public string canaletao { get; set; }
        [MaxLength(3)]
        public string linha { get; set; }
        [MaxLength(3)]
        public string coluna { get; set; }
        [MaxLength(4)]
        public string qtde { get; set; }

        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
