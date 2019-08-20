using System;

namespace Prodfy.Models
{
    public class EstoqueViveiro
    {
        public Lote lote { get; set; }
        public Muda muda { get; set; }
        public Qualidade qualidade { get; set; }
        public Estaq estaq { get; set; }
        public DateTime dataSelecao { get; set; }
    }
}
