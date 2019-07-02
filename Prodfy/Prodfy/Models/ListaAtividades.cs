using System;

namespace Prodfy.Models
{
    public class ListaAtividades
    {
        public int idatividade { get; set; }        
        public int colaborador_id { get; set; }
        public string nome_interno { get; set; }
        public int lista_atv_id { get; set; }
        public string codigo { get; set; }
        public string titulo { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_fim { get; set; }
        public string codigoTitulo
        {
            get => $"{codigo} - {titulo}";
        }
    }
}
