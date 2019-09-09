using Prodfy.Helpers;
using Prodfy.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prodfy.Services.Repository
{
    public class InvItemRepository : IRepository<Inv_Item>
    {
        DataBase dataBase;

        public InvItemRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Inv_Item inv_item)
        {
            try
            {
                dataBase._conexao.Insert(inv_item);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public List<string> ObterLoteParaEstoqueViveiro()
        {
            var dadosLote = dataBase._conexao.Query<Lote>("select * from Lote");
            List<Lote> listaLotes = new List<Lote>();

            for (int i = 0; i < dadosLote.Count; i++)
            {
                listaLotes.Add(dadosLote[i]);
            }

            var dadosInvItem = dataBase._conexao.Query<Inv_Item>("select * from Inv_Item");
            List<Inv_Item> listaInvItens = new List<Inv_Item>();

            for (int i = 0; i < dadosInvItem.Count; i++)
            {
                listaInvItens.Add(dadosInvItem[i]);
            }

            var query = from invItem in listaInvItens
                        join lote in listaLotes on invItem.lote_id equals lote.lote_id
                        select new
                        {
                            invItem.lote_id,
                            lote.produto_id,
                            lote.codigo,
                            lote.objetivo,
                            lote.cliente
                        };

            List<string> dadosLoteEstoqueViveiro = new List<string>();

            

            //foreach (var item in query)
            //{
            //    dadosLoteEstoqueViveiro.Add(item.ToString());
            //}

            //var loteEstoqueViveiro = new
            //{
            //    dadosLoteEstoqueViveiro.produto_id,
            //    dadosLoteEstoqueViveiro.codigo,
            //    dadosLoteEstoqueViveiro.objetivo,
            //    dadosLoteEstoqueViveiro.cliente,
            //    invItem = dadosLoteEstoqueViveiro.lote_id
            //};

            //var ret = dadosLoteEstoqueViveiro;

            return dadosLoteEstoqueViveiro;
        }

        public List<Inv_Item> ObterDataEstaquemento(int? loteId, int? mudaId, int? qualidadeId)
        {
            var listaInvItem = dataBase._conexao.Query<Inv_Item>("SELECT * FROM Inv_Item"/*"SELECT data_estaq FROM Inv_Item"*/);

            List<Inv_Item> resultado = new List<Inv_Item>();

            var dados =
               from dataEstaquemanto in listaInvItem
               where dataEstaquemanto.lote_id == loteId && dataEstaquemanto.muda_id == mudaId && dataEstaquemanto.qualidade_id == qualidadeId
               select dataEstaquemanto;

            foreach (var item in dados)
            {
                resultado.Add(item);
            }

            return resultado;
        }

        public List<Inv_Item> ObterDataSelecao(int loteId, int mudaId, int qualidadeId, string dataEstaqueamento)
        {
            var listaInvItem = dataBase._conexao.Query<Inv_Item>("SELECT * FROM Inv_Item");

            List<Inv_Item> resultado = new List<Inv_Item>();

            var dados =
                from dataSelecao in listaInvItem
                where dataSelecao.data_estaq == Convert.ToDateTime(dataEstaqueamento) || dataSelecao.lote_id == loteId || dataSelecao.muda_id == mudaId || dataSelecao.qualidade_id == qualidadeId
                select dataSelecao;

            foreach (var item in dados)
            {
                resultado.Add(item);
            }

            return resultado;
        }

        public SQLite.TableQuery<Inv_Item> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Inv_Item>();
        }

        public void Editar(Inv_Item entidade)
        {
            throw new NotImplementedException();
        }

        public Inv_Item ObterDados()
        {
            throw new NotImplementedException();
        }

        public Inv_Item ObterDadosPorId(string id)
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

        public List<Inv_Item> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
