using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prodfy.Services.Repository
{
    public class HistoricoRepository : IRepository<Historico>
    {
        private DataBase dataBase;

        public HistoricoRepository()
        {
            dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var total = dataBase._conexao.Table<Inventario>().Count();

            if (total > 0)
                return total;

            return 0;
        }

        public void Adicionar(Historico historico)
        {
            try
            {
                dataBase._conexao.Insert(historico);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
           
        }

        public List<ListaHistorico> ListaDeHistoricos()
        {
            var dadosHistorico = dataBase._conexao.Query<Historico>("select * from Historico");
            List<Historico> listaHistoricos = new List<Historico>();

            for (int i = 0; i < dadosHistorico.Count; i++)
            {
                listaHistoricos.Add(dadosHistorico[i]);
            }

            var dadosLote = dataBase._conexao.Query<Lote>("select * from Lote");
            List<Lote> listaLotes = new List<Lote>();

            for (int i = 0; i < dadosLote.Count; i++)
            {
                listaLotes.Add(dadosLote[i]);
            }

            var query = from lote in listaLotes
                        join historico in listaHistoricos on lote.lote_id equals historico.lote_id
                        orderby historico.data descending
                        select new
                        {
                            historico.data,
                            lote.codigo,
                            historico.titulo
                        };

            var dados = query;

            List<ListaHistorico> listaDadosHistoricos = new List<ListaHistorico>();

            foreach (var item in dados)
            {
                var lista = new ListaHistorico
                {
                    Data = item.data.ToString(),
                    Codigo = item.codigo,
                    Titulo = item.titulo
                };

                listaDadosHistoricos.Add(lista);
            }           

            return listaDadosHistoricos;
        }

        public TableQuery<Historico> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            dataBase._conexao.Execute("Delete From Historico");
        }

        public void Editar(Historico entidade)
        {
            throw new NotImplementedException();
        }

        public Historico ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Historico> ObterTodos()
        {
            return dataBase._conexao.Table<Historico>().OrderBy(h => h.idHistorico).ToList();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public Historico ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(int id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(int id, string codigo)
        {
            throw new NotImplementedException();
        }
    }
}
