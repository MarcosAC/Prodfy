using SQLite;
using System;

namespace Prodfy.Models
{
    public class Expedido
    {
        [PrimaryKey, AutoIncrement]
        public int idExpedido { get; set; }
        public int expedido_id { get; set; }
        public int lote_id { get; set; }
        public int ponto_controle_id { get; set; }
        public int estagio_id { get; set; }
        public int muda_id { get; set; }
        public int qualidade_id { get; set; }
        public DateTime data_estaq { get; set; }
        public DateTime data_selecao { get; set; }
        public int qtde_estaq { get; set; }
        public int qtde_disp { get; set; }
        public int qtde_com_tubete { get; set; }
        public int qtde_sem_tubete { get; set; }
        public int qtde { get; set; }
        public int colaborador_id { get; set; }
        public int exped_dest_id { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_fim { get; set; }
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
