using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class PerdaRepository : IRepository<Perda>
    {
        private DataBase dataBase;

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

        public TableQuery<Perda> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void DeletarTodos()
        {
            dataBase._conexao.Execute("Delete From Perda");
        }

        public void Editar(Perda entidade)
        {
            throw new NotImplementedException();
        }

        public Perda ObterDados()
        {
            throw new NotImplementedException();
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

        public string ObterLoteInfo(string codigo)
        {
            throw new NotImplementedException();
        }

        public Perda ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterMudaInfo(int id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(int id, string codigo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            dataBase._conexao.Delete<Perda>(id);
        }
    }
}
