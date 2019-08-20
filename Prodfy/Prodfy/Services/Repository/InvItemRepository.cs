using Prodfy.Helpers;
using Prodfy.Models;
using System;
using System.Collections.Generic;

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
