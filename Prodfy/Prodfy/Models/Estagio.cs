﻿using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Estagio")]
    public class Estagio
    {
        [PrimaryKey, AutoIncrement]
        public int idEstagio { get; set; }
        public int estagio_id { get; set; }
        public int produto_id { get; set; }
        public int ponto_controle_id { get; set; }

        [MaxLength(45)]
        public string codigo { get; set; }
        [MaxLength(80)]
        public string titulo { get; set; }
        
        public int maturacao { get; set; }

        [MaxLength(2)]
        public string unidade { get; set; }
        
        public int maturacao_seg { get; set; }
        public int ind_alertas { get; set; }
        public int ordem { get; set; }
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
