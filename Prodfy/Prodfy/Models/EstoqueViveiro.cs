using System;
using System.Collections.Generic;

namespace Prodfy.Models
{
    public class EstoqueViveiro
    {
        public List<Lote> lote { get; set; }
        public List<Muda> muda { get; set; }
        public List<Qualidade> qualidade { get; set; }
        public DateTime estaq { get; set; }
        public DateTime dataSelecao { get; set; }
    }
}
