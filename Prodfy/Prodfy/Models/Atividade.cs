using SQLite;

namespace Prodfy.Models
{
    public class Atividade
    {
        [PrimaryKey, AutoIncrement]
        public int idAtividade { get; set; }
        public string disp_Id { get; set; }
        public string colaborador_id { get; set; }
        public string lista_atv_id { get; set; }
        public string data_inicio { get; set; }
        public string data_fim { get; set; }
        public string obs { get; set; }
        public string last_update { get; set; }
        public int ind_sinc { get; set; }
    }
}
