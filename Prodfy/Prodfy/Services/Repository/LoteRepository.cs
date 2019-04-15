using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class LoteRepository : IRepository<Lote>
    {
        private DataBase _dataBase;

        public LoteRepository()
        {
            _dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var totalRegistro = _dataBase._conexao.Table<Lote>().Count();

            if (totalRegistro > 0)
                return totalRegistro;

            return 0;
        }

        public void ObterDados(string id)
        {
            var dados = _dataBase._conexao.Execute("SELECT " +
                                                        "L.lote_id, L.codigo, L.objetivo, L.cliente, P.titulo " +
                                                   "FROM " +
                                                        "Lote L " +
                                                   "LEFT JOIN " +
                                                        "Produto P " +
                                                   "ON " +
                                                        "P.produto_id = L.produto_id " +
                                                   "WHERE " +
                                                        "L.lote_id = " + id + 
                                                   "LIMIT 1");


            
            //var dadosLote = new
            //{
            //    id = dados.,
            //    codigo = item.lote_id,
            //    _cliente = item.cliente
            //};

            //foreach (var item in dados)
            //{
            //    var dadosLote = new
            //    {
            //        id = item.idLote,
            //        codigo = item.lote_id,
            //        _cliente = item.cliente
            //    };
            //}

            //return null;

        }

        public void Adicionar(Lote entidade)
        {
            throw new NotImplementedException();
        }

        public TableQuery<Lote> AsQueryable()
        {
            var dados = _dataBase._conexao.Table<Lote>();
            return dados;
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Lote entidade)
        {
            throw new NotImplementedException();
        }

        public Lote ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Lote> ObterTodos()
        {
            throw new NotImplementedException();
        }        
    }
}
