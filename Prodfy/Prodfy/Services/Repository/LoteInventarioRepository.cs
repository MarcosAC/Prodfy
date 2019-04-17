using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class LoteInventarioRepository : IRepository<Lote_Inventario>
    {
        private DataBase dataBase;

        public LoteInventarioRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Lote_Inventario lote_Inventario)
        {
            try
            {
                dataBase._conexao.Insert(lote_Inventario);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public TableQuery<Lote_Inventario> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Lote_Inventario entidade)
        {
            throw new NotImplementedException();
        }

        public Lote_Inventario ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Lote_Inventario> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
