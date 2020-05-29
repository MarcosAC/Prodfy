using Prodfy.Helpers;
using Prodfy.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prodfy.Services.Repository
{
    public class LoteRepository : IRepository<Lote>
    {
        private readonly DataBase dataBase;

        public LoteRepository()
        {
            dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var totalRegistro = dataBase._conexao.Table<Lote>().Count();

            if (totalRegistro > 0)
                return totalRegistro;

            return 0;
        }

        public string ObterLoteInfo(string codigo)
        {
            var dadosLote = dataBase._conexao.Query<Lote>("select * from Lote");
            List<Lote> listaLotes = new List<Lote>();

            for (int i = 0; i < dadosLote.Count; i++)
            {
                listaLotes.Add(dadosLote[i]);
            }

            var dadosProduto = dataBase._conexao.Query<Produto>("select * from Produto");
            List<Produto> listaProdutos = new List<Produto>();

            for (int i = 0; i < dadosProduto.Count; i++)
            {
                listaProdutos.Add(dadosProduto[i]);
            }

            var query = from lote in listaLotes
                        join produto in listaProdutos on lote.produto_id equals produto.produto_id into gj
                        from produto in gj.DefaultIfEmpty()
                        where lote.codigo == codigo
                        select new
                        {
                            lote.lote_id,
                            lote.codigo,
                            lote.objetivo,
                            lote.cliente,
                            produto.titulo
                        };

            var dadosLoteInfo = query.FirstOrDefault();

            var loteInfo = new
            {
                dadosLoteInfo.lote_id,
                dadosLoteInfo.codigo,
                dadosLoteInfo.objetivo,
                dadosLoteInfo.cliente,
                produto = dadosLoteInfo.titulo
            };

            string ret = string.Empty;

            if (loteInfo.lote_id != 0)
            {
                ret = $"1||{loteInfo.lote_id}|{loteInfo.codigo}|{loteInfo.objetivo}|{loteInfo.cliente}|{loteInfo.produto}|";
            }
            else
            {
                ret = "0|Registro não encontrado!|";
            }

            return ret;
        }        

        public void ListaLotes()
        {
            var listaLotes = dataBase._conexao.Query<Lote>("Select * From Lote");
        }

        public void Adicionar(Lote lote)
        {
            try
            {
                dataBase._conexao.Insert(lote);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public string ObterLoteId(string codigo)
        {
            var dados = dataBase._conexao.Query<Lote>($"SELECT lote_id FROM Lote WHERE codigo = '{codigo}' LIMIT 1");

            string lotePorId = string.Empty;
            string ret = string.Empty;

            foreach (var item in dados)
            {
                lotePorId = item.lote_id.ToString();
            }

            if (!string.IsNullOrEmpty(lotePorId))
            {
                ret = $"1||{lotePorId}|";
            }
            else
            {
                ret = "0|Registro não encontrado!||";
            }

            return ret;
        }

        public string ObterLoteProdutoId(string codigo)
        {
            var dados = dataBase._conexao.Query<Lote>($"SELECT produto_id FROM Lote WHERE codigo = '{codigo}' LIMIT 1");

            string loteProdutoPorId = string.Empty;
            string ret = string.Empty;

            foreach (var item in dados)
            {
                loteProdutoPorId = item.produto_id.ToString();
            }

            if (!string.IsNullOrEmpty(loteProdutoPorId))
            {
                ret = $"1||{loteProdutoPorId}|";
            }
            else
            {
                ret = "0|Registro não encontrado!||";
            }

            return ret;
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Lote>();
        }

        public List<Lote> ObterTodos()
        {
            return dataBase._conexao.Query<Lote>($"SELECT lote_id, produto_id, codigo, objetivo, cliente FROM Lote ORDER BY 3 desc");
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

        public string ObterLoteInfoPorId(string loteId)
        {
            var loteInfo = dataBase._conexao.Query<LotesEstoqueViveiro>("SELECT " +
                                                                        "L.lote_id, " +
                                                                        "L.codigo, " +
                                                                        "L.objetivo, " +
                                                                        "L.cliente, " +
                                                                        "P.titulo " +
                                                                     "FROM Lote L " +
                                                                     "LEFT JOIN Produto P " +
                                                                     "ON P.produto_id = L.produto_id " +
                                                                     $"WHERE L.lote_id = '{loteId}'" +
                                                                     "LIMIT 1");            

            string ret = string.Empty;

            if (loteInfo[0].lote_id != 0)
            {
                ret = $"1||{loteInfo[0].lote_id}|{loteInfo[0].codigo}|{loteInfo[0].objetivo}|{loteInfo[0].cliente}|{loteInfo[0].titulo}|";
            }
            else
            {
                ret = "0|Registro não encontrado!|";
            }

            return ret;
        }
    }
}
