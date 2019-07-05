using System;

namespace Prodfy.Models
{
    public class ListaPerdas
    {
        public int idperda { get; set; }
        public int disp_id { get; set; }
        public int lote_id { get; set; }
        public string codigo { get; set; }
        public int muda_id { get; set; }
        public string nome_interno { get; set; }
        public string especie_nome_cientifico { get; set; }
        public DateTime data { get; set; }
        public int qtde { get; set; }
        public string nomeInternoCientifico
        {
            get => $"{nome_interno} - {especie_nome_cientifico}";
        }
    }
}
