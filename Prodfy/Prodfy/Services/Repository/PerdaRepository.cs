using Prodfy.Helpers;
using Prodfy.Models;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class PerdaRepository : IRepository<Perda>
    {
        private readonly DataBase dataBase;

        public PerdaRepository()
        {
            dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var total = dataBase._conexao.Table<Perda>().Count();

            if (total > 0)
                return total;

            return 0;
        }

        public void Adicionar(Perda perda)
        {
            dataBase._conexao.Insert(perda);
        }

        public void DeletarTodos()
        {
            dataBase._conexao.Execute("Delete From Perda");
        }

        public List<Perda> ObterTodos()
        {
            return dataBase._conexao.Table<Perda>().OrderBy(p => p.idPerda).ToList();
        }

        public List<ListaPerdas> ObterTodasPerdas()
        {
            return dataBase._conexao.Query<ListaPerdas>("SELECT " +
                                                           "AA.idperda, " +
                                                           "AA.disp_id, " +
                                                           "L.lote_id, " +
                                                           "L.codigo, " +
                                                           "AA.muda_id, " +
                                                           "M.nome_interno, " +
                                                           "M.especie_nome_cientifico, " +
                                                           "AA.data, " +
                                                           "AA.qtde " +
                                                        "FROM " +
                                                           "Perda AA " +
                                                        "INNER JOIN " +
                                                           "Lote L " +
                                                        "ON L.lote_id = AA.lote_id " +
                                                        "INNER JOIN " +
                                                           "Muda M ON M.muda_id = AA.muda_id " +
                                                        "ORDER BY AA.data");
        }

        public List<ListaPerdas> ListaDePerdas(string filtro)
        {
            var listaDePerdas = dataBase._conexao.Query<ListaPerdas>("SELECT " +
                                                                        "AA.idperda, " +
                                                                        "AA.disp_id, " +
                                                                        "L.lote_id, " +
                                                                        "L.codigo, " +
                                                                        "AA.muda_id, " +
                                                                        "M.nome_interno, " +
                                                                        "M.especie_nome_cientifico, " +
                                                                        "AA.data, " +
                                                                        "AA.qtde " +
                                                                     "FROM " +
                                                                        "Perda AA " +
                                                                     "INNER JOIN " +
                                                                        "Lote L " +
                                                                     "ON L.lote_id = AA.lote_id " +
                                                                     "INNER JOIN " +
                                                                        "Muda M ON M.muda_id = AA.muda_id " +
                                                                     "ORDER BY AA.data");

            if (string.IsNullOrEmpty(filtro))
                return ObterTodasPerdas();

            return listaDePerdas.FindAll(l => l.codigo.Contains(filtro));
        }

        public void Deletar(int id)
        {
            dataBase._conexao.Delete<Perda>(id);
        }
    }
}
