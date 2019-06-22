using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Lista_Atv")]
    public class Lista_Atv
    {
        [PrimaryKey, AutoIncrement]
        public int idLista_Atv { get; set; }
        public int lista_atv_id { get; set; }

        [MaxLength(10)]
        public string codigo { get; set; }
        [MaxLength(180)]
        public string titulo { get; set; }
        [MaxLength(255)]
        public string drescr { get; set; }

        public int media_exec { get; set; }        
        public int definicao { get; set; }
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }

        public string atividade
        {
            get => $"{codigo} - {titulo}";
        }
    }
}
