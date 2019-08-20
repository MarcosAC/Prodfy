using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

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

        public List<Lote> ListaLotesEstoqueViveiro()
        {
            var lotes = dataBase._conexao.Query<Lote>("SELECT " +
                                                        "AA.lote_id, " +
                                                        "L.produto_id, " +
                                                        "L.codigo, " +
                                                        "L.objetivo, " +
                                                        "L.cliente " +
                                                      "FROM " +
                                                        "Inv_Item AA " +
                                                      "INNER JOIN " +
                                                        "Lote L " +
                                                      "ON " +
                                                        "L.lote_id = AA.lote_id " +
                                                      "GROUP BY " +
                                                        "AA.lote_id " +
                                                      "ORDER BY " +
                                                        "3 DESC");

            //var lotes = dataBase._conexao.Query<Lote>("SELECT * FROM Lote");

            return lotes;
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
