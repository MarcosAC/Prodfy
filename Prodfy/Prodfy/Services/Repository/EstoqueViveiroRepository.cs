using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class EstoqueViveiroRepository : IRepository<EstoqueViveiro>
    {
        private DataBase dataBase;

        public EstoqueViveiroRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(EstoqueViveiro entidade)
        {
            throw new NotImplementedException();
        }

        public TableQuery<EstoqueViveiro> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletarTodos()
        {
            throw new NotImplementedException();
        }

        public void Editar(EstoqueViveiro entidade)
        {
            throw new NotImplementedException();
        }

        public EstoqueViveiro ObterDados()
        {
            throw new NotImplementedException();
        }

        public EstoqueViveiro ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(int id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public List<EstoqueViveiro> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public List<LotesEstoqueViveiro> ObterLotesEstoqueViveiro()
        {
            var listaLotes = dataBase._conexao.Query<LotesEstoqueViveiro>("SELECT " +
                                                                              "AA.lote_id, " +
                                                                              "L.produto_id, " +
                                                                              "L.codigo, " +
                                                                              "L.objetivo, " +
                                                                              "L.cliente " +
                                                                          "FROM " +
                                                                              "Inv_Item AA " +
                                                                          "INNER JOIN Lote L " +
                                                                          "ON L.lote_id = AA.lote_id " +
                                                                          "GROUP BY AA.lote_id " +
                                                                          "ORDER BY 3 DESC");

            return listaLotes;
        }

        public List<MudasEstoqueViveiro> ObterMudasEstoqueViveiro(int loteId)
        {
            string query = "SELECT " +
                                "AA.muda_id, " +
                                "M.nome_interno " +
                           "FROM " +
                                "Inv_Item AA " +
                           "INNER JOIN Muda M " +
                           "ON M.muda_id = AA.muda_id ";

            string where = string.Empty;
            string cap = string.Empty;

            if (loteId > 0)
            {
                if (!string.IsNullOrEmpty(where))
                    cap = " AND ";

                where += $"{cap}AA.lote_id = {loteId}";
            }

            if (!string.IsNullOrEmpty(where))
                where = $" WHERE {where}";

            query += $"{where} GROUP BY AA.muda_id ORDER BY M.nome_interno";

            var listaMudas = dataBase._conexao.Query<MudasEstoqueViveiro>(query);

            return listaMudas;
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
