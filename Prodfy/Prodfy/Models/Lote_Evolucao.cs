using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Lote_Evolucao")]
    public class Lote_Evolucao
    {
        [PrimaryKey, AutoIncrement]
        public int idLote_Evolucao { get; set; }
        public int lote_evolucao_id { get; set; }
        public int lote_id { get; set; }
        public int ponto_controle_id { get; set; }
        public int estagio_id { get; set; }
        public int muda_id { get; set; }
        public DateTime data_estaq { get; set; }
        public DateTime data_selecao { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_fim { get; set; }
        public int qtde_total { get; set; }
        public int qtde { get; set; }        
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
