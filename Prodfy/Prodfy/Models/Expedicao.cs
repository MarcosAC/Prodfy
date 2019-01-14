using SQLite;

namespace Prodfy.Models
{
    [Table("Expedicao")]
    public class Expedicao
    {
        [PrimaryKey, AutoIncrement]
        public int idExpedicao { get; set; }
        public string disp_id { get; set; }        
        public string lote_id { get; set; }
        public string ponto_controle_id { get; set; }
        public string estagio_id { get; set; }
        public string muda_id { get; set; }
        public string data_selecao { get; set; }
        public string data_estaq { get; set; }
        public string qtde_estaq { get; set; }
        public string qtde_com_tubete { get; set; }
        public string qtde_sem_tubete { get; set; }
        public string qtde { get; set; }
        public string colaborador_id { get; set; }
        public string data_inicio { get; set; }
        public string data_fim { get; set; }
        public string exped_dest_id { get; set; }
        public string obs { get; set; }        
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
