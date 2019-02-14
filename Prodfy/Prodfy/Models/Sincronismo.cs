namespace Prodfy.Models
{
    public class Sincronismo
    {
        public int sinc_stat { get; set; }
        public string sinc_msg { get; set; }
        public string sinc_date { get; set; }
        public string disp_num { get; set; }
        public string senha { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string empresa { get; set; }
        public int? autosinc { get; set; }
        public string autosinc_time { get; set; }
        public int? ind_ident { get; set; }
        public int? ind_atv { get; set; } // Atividade
        public int? ind_inv { get; set; } // Inventario
        public int? ind_per { get; set; } // Perda
        public int? ind_hist { get; set; } // Historico
        public int? ind_evo { get; set; } // Evolução
        public int? ind_oco { get; set; } // Ocorrencia
        public int? ind_mnt { get; set; } // Mediçã0
        public int? ind_exp { get; set; } // Expedição        
        public int? uso_liberado { get; set; }
        public string dht_last_sincr { get; set; }

        //public Produto[] produto { get; set; }
        //public Objetivo[] objetivo { get; set; }
        //public Ponto_Controle[] ponto_controle { get; set; }
        //public Estagio[] estagio { get; set; }
        //public Muda[] muda { get; set; }
        //public Lote[] lote { get; set; }
        //public Perda_Motivo[] perda_motivo { get; set; }
        //public Monit[] monit { get; set; }
        //public Monit_Cod_Arv[] monit_cod_arv { get; set; }
        //public Monit_Parcela[] monit_parcela { get; set; }
        //public Colaborador[] colaborador { get; set; }
        //public Lista_Atv[] lista_atv { get; set; }
        //public Qualidade[] qualidade { get; set; }
        //public Exped_Dest[] exped_dest { get; set; }
        //public Lote_Evolucao[] lote_evolucao { get; set; }
        //public Lote_Inventario[] lote_inventario { get; set; }
        //public Estaq[] estaq { get; set; }

        //public class Produto
        //{
        //    public int produto_id { get; set; }
        //    public string titulo { get; set; }
        //}

        //public class Objetivo
        //{
        //    public int objetivo_id { get; set; }
        //    public string titulo { get; set; }
        //}

        //public class Ponto_Controle
        //{
        //    public int ponto_controle_id { get; set; }
        //    public int produto_id { get; set; }
        //    public string codigo { get; set; }
        //    public string titulo { get; set; }
        //    public int maturacao { get; set; }
        //    public string unidade { get; set; }
        //    public int maturacao_seg { get; set; }
        //    public int ind_alertas { get; set; }
        //}

        //public class Estagio
        //{
        //    public int estagio_id { get; set; }
        //    public int produto_id { get; set; }
        //    public int ponto_controle_id { get; set; }
        //    public string codigo { get; set; }
        //    public string titulo { get; set; }
        //    public int maturacao { get; set; }
        //    public string unidade { get; set; }
        //    public int maturacao_seg { get; set; }
        //    public int ind_alertas { get; set; }
        //}

        //public class Muda
        //{
        //    public int muda_id { get; set; }
        //    public string nome_interno { get; set; }
        //    public string nome { get; set; }
        //    public string especie_nome_comum { get; set; }
        //    public string especie_nome_especie { get; set; }
        //    public string especie_nome_cientifico { get; set; }
        //    public string origem { get; set; }
        //    public string viveiro { get; set; }
        //    public string canaletao { get; set; }
        //    public string linha { get; set; }
        //    public string coluna { get; set; }
        //    public string qtde { get; set; }
        //}

        //public class Lote
        //{
        //    public int lote_id { get; set; }
        //    public int produto_id { get; set; }
        //    public string codigo { get; set; }
        //    public string objetivo { get; set; }
        //    public string cliente { get; set; }
        //}

        //public class Perda_Motivo
        //{
        //    public int perda_motivo_id { get; set; }
        //    public string motivo { get; set; }
        //}

        //public class Monit
        //{
        //    public int monit_id { get; set; }
        //    public string codigo { get; set; }
        //    public int produto_id { get; set; }
        //    public int objetivo_id { get; set; }
        //    public string data_plantio { get; set; }
        //    public string esp_linha { get; set; }
        //    public string esp_plantas { get; set; }
        //    public string projeto { get; set; }
        //    public string talhao { get; set; }
        //    public int num_trat { get; set; }
        //    public int num_rep { get; set; }
        //    public string pi_lat_g { get; set; }
        //    public string pi_lat_m { get; set; }
        //    public string pi_lat_s { get; set; }
        //    public string pi_lat_d { get; set; }
        //    public string pi_lat { get; set; }
        //    public string pi_lng_g { get; set; }
        //    public string pi_lng_m { get; set; }
        //    public string pi_lng_s { get; set; }
        //    public string pi_lng_d { get; set; }
        //    public string pi_lng { get; set; }
        //}

        //public class Monit_Cod_Arv
        //{
        //    public int monit_cod_arv_id { get; set; }
        //    public string codigo { get; set; }
        //    public string descr { get; set; }
        //}

        //public class Monit_Parcela
        //{
        //    public int monit_parcela_id { get; set; }
        //    public int monit_id { get; set; }
        //    public int parcela { get; set; }
        //    public int muda_id { get; set; }
        //}

        //public class Colaborador
        //{
        //    public int colaborador_id { get; set; }
        //    public string nome_interno { get; set; }
        //    public string nome { get; set; }
        //}

        //public class Lista_Atv
        //{
        //    public int lista_atv_id { get; set; }
        //    public string codigo { get; set; }
        //    public string titulo { get; set; }
        //    public string descr { get; set; }
        //    public int media_exec { get; set; }
        //    public int definicao { get; set; }
        //}

        //public class Qualidade
        //{
        //    public int qualidade_id { get; set; }
        //    public string codigo { get; set; }
        //    public string titulo { get; set; }
        //}

        //public class Exped_Dest
        //{
        //    public int exped_dest_id { get; set; }
        //    public string titulo { get; set; }
        //    public string descr { get; set; }
        //}

        //public class Lote_Evolucao
        //{
        //    public int lote_evolucao_id { get; set; }
        //    public int lote_id { get; set; }
        //    public int ponto_controle_id { get; set; }
        //    public int estagio_id { get; set; }
        //    public int muda_id { get; set; }
        //    public string data_estaq { get; set; }
        //    public string data_selecao { get; set; }
        //    public string data_inicio { get; set; }
        //    public string data_fim { get; set; }
        //    public int qtde_total { get; set; }
        //    public int qtde { get; set; }
        //}

        //public class Lote_Inventario
        //{
        //    public int lote_inventario_id { get; set; }
        //    public int lote_id { get; set; }
        //    public int muda_id { get; set; }
        //    public string data_estaq { get; set; }
        //    public string data_selecao { get; set; }
        //    public int qtde { get; set; }
        //    public int colab_estaq_id { get; set; }
        //    public string colab_estaq { get; set; }
        //    public int colab_selecao_id { get; set; }
        //    public string colab_selecao { get; set; }
        //    public int qualidade_id { get; set; }
        //    public string qualidade { get; set; }
        //    public string latitude { get; set; }
        //    public string longitude { get; set; }
        //}

        //public class Estaq
        //{
        //    public int lote_inventario_id { get; set; }
        //    public int lote_id { get; set; }
        //    public string lote { get; set; }
        //    public int muda_id { get; set; }
        //    public string muda { get; set; }
        //    public string data_estaq { get; set; }
        //    public int qtde { get; set; }
        //    public int qualidade_id { get; set; }
        //    public string qualidade { get; set; }
        //    public int colab_estaq_id { get; set; }
        //    public string colab_estaq { get; set; }
        //}
    }
}
