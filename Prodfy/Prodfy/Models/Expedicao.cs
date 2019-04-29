using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Expedicao")]
    public class Expedicao
    {
        [PrimaryKey, AutoIncrement]
        public int idExpedicao { get; set; }
        public int disp_id { get; set; }        
        public int lote_id { get; set; }
        public int ponto_controle_id { get; set; }
        public int estagio_id { get; set; }
        public int muda_id { get; set; }
        public DateTime data_selecao { get; set; }
        public DateTime data_estaq { get; set; }
        public int qtde_estaq { get; set; }
        public int qtde_com_tubete { get; set; }
        public int qtde_sem_tubete { get; set; }
        public int qtde { get; set; }
        public int colaborador_id { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_fim { get; set; }
        public int exped_dest_id { get; set; }
        public string obs { get; set; }        
        public string latitude { get; set; }
        public string longitude { get; set; }
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
