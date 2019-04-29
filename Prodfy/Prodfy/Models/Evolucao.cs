using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Evolucao")]
    public class Evolucao
    {
        [PrimaryKey, AutoIncrement]
        public int idEvolucao { get; set; }
        public DateTime data { get; set; }
        public int disp_id { get; set; }
        public int lote_id { get; set; }
        public int ponto_controle_id { get; set; }
        public int estagio_id { get; set; }
        public int muda_id { get; set; }
        public int ind_muda_todas { get; set; }
        public DateTime data_estaq { get; set; }
        public int qtde_total { get; set; }
        public int qtde { get; set; }
        public DateTime data_selecao { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_fim { get; set; }
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
