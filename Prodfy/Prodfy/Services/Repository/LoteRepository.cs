using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prodfy.Services.Repository
{
    public class LoteRepository : IRepository<Lote>
    {
        private DataBase dataBase;

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

        public string ObterInformacoesParaIdentificacao(string codigo)
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

        public TableQuery<Lote> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Lote>();
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
            return dataBase._conexao.Query<Lote>($"SELECT lote_id, produto_id, codigo, objetivo, cliente FROM Lote ORDER BY 3 desc");
        }

        public string ObterLotePorId(string id)
        {
            var dados = dataBase._conexao.Query<Lote>($"SELECT lote_id FROM Lote WHERE codigo = '{id}' LIMIT 1");

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

        public string ObterLoteProdutoPorId(string id)
        {
            var dados = dataBase._conexao.Query<Lote>($"SELECT produto_id FROM Lote WHERE codigo = '{id}' LIMIT 1");

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

        public string ObterInformacoesParaIdentificacao(int id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(int id, string codigo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Lote ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
