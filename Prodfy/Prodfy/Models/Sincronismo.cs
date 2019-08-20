using System;

namespace Prodfy.Models
{
    public class Sincronismo
    {
        public int sinc_stat { get; set; }
        public string sinc_msg { get; set; }
        public DateTime sinc_date { get; set; }
        public int disp_num { get; set; }
        public string senha { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string empresa { get; set; }
        public int? autosinc { get; set; }
        public int? autosinc_time { get; set; }
        public int? ind_ident { get; set; }
        public int? ind_atv { get; set; } // Atividade
        public int? ind_inv { get; set; } // Inventario
        public int? ind_per { get; set; } // Perda
        public int? ind_hist { get; set; } // Historico
        public int? ind_mov { get; set; } // Movimentação
        public int? ind_oco { get; set; } // Ocorrencia
        public int? ind_mnt { get; set; } // Medição
        public int? ind_exp { get; set; } // Expedição          
        public int? uso_liberado { get; set; }
        public DateTime dht_last_sincr { get; set; } 

        public Produto[] produto { get; set; }
        public Objetivo[] objetivo { get; set; }
        public Ponto_Controle[] ponto_controle { get; set; }
        public Estagio[] estagio { get; set; }
        public Muda[] muda { get; set; }
        public Lote[] lote { get; set; }
        public Perda_Motivo[] perda_motivo { get; set; }
        public Monit[] monit { get; set; }
        public Monit_Cod_Arv[] monit_cod_arv { get; set; }
        public Monit_Parcela[] monit_parcela { get; set; }
        public Colaborador[] colaborador { get; set; }
        public Lista_Atv[] lista_atv { get; set; }
        public Qualidade[] qualidade { get; set; }
        public Exped_Dest[] exped_dest { get; set; }
        public Estaq[] estaq { get; set; }
        public Inv_Item[] inv_item { get; set; }
        public Inv[] inv { get; set; }
        public Inv_Evo[] inv_evo { get; set; }
    }
}
