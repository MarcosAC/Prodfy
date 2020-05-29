using Prodfy.Helpers;
using Prodfy.Models;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class PerdaMotivoRepository
    {
        private readonly DataBase dataBase;

        public PerdaMotivoRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Perda_Motivo perda_Motivo)
        {
            try
            {
                dataBase._conexao.Insert(perda_Motivo);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Perda_Motivo>();
        }

        public List<Perda_Motivo> ObterTodos()
        {
            return dataBase._conexao.Query<Perda_Motivo>("SELECT perda_motivo_id, motivo FROM Perda_Motivo ORDER BY 2");
        }
    }
}
