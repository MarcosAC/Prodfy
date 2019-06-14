using System;

namespace Prodfy.Models
{
    public class ListaHistorico
    {
        public int IdHistorico { get; set; }
        public DateTime Data { get; set; }
        public string Codigo { get; set; }        
        public string Titulo { get; set; }
    }
}
