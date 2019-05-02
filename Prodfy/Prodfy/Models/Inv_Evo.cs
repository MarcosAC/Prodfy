using SQLite;
using  System;

namespace Prodfy.Models
{
    [Table("Inv_Evo")]
    public class Inv_Evo
    {
        [PrimaryKey, AutoIncrement]
        public int idInv_Evo { get; set; }
        public int inv_evo_id { get; set; }
        public int inv_item_id { get; set; }
        public int ponto_controle_ori_id { get; set; }
        public int estagio_ori_id { get; set; }
        public int qualidade_ori_id { get; set; }
        public DateTime data_estaq { get; set; }
        public DateTime data_selecao { get; set; }
        public int qtde { get; set; }
        public int qtde_amostragem { get; set; }
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
