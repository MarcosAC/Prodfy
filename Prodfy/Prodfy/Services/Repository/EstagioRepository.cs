using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodfy.Services.Repository
{
    public class EstagioRepository : IRepository<Estagio>
    {
        private DataBase dataBase;

        public EstagioRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Estagio estagio)
        {
            try
            {
                dataBase._conexao.Insert(estagio);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public async Task<List<Estagio>> ListaLocalEstagio(int pontoControleId, int loteId, int mudaId, DateTime dataEstaq)
        {
            await App.Current.MainPage.DisplayAlert("Erro", "", "OK");
            return null;
        }

        public TableQuery<Estagio> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Estagio entidade)
        {
            throw new NotImplementedException();
        }

        public Estagio ObterDados()
        {
            throw new NotImplementedException();
        }

        public Estagio ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(int codigo)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public List<Estagio> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
