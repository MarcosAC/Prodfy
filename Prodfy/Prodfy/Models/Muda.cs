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
        public string nome_interno { get; set; }
        public string nome { get; set; }
        public string especie_nome_comum { get; set; }
        public string especie_nome_especie { get; set; }
        public string especie_nome_cientifico { get; set; }
        public string origem { get; set; }
        public string viveiro { get; set; }
        public string canaletao { get; set; }
        public string linha { get; set; }
        public string coluna { get; set; }
        public string qtde { get; set; }
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
