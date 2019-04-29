﻿using SQLite;
using System;

namespace Prodfy.Models
{
    [Table("Colaborador")]
    public class Colaborador
    {
        [PrimaryKey, AutoIncrement]
        public int idColaborador { get; set; }
        public int colaborador_id { get; set; }
        public string nome_interno { get; set; }
        public string nome { get; set; }
        public DateTime last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
