using SQLite;
using System;

namespace Prodfy.Models
{
    public class Atividade
    {
        [PrimaryKey, AutoIncrement]
        public int idAtividade { get; set; }
        public int disp_Id { get; set; }
        public int colaborador_id { get; set; }
        public int lista_atv_id { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_fim { get; set; }

        [MaxLength(500)]
        public string obs { get; set; }

        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
