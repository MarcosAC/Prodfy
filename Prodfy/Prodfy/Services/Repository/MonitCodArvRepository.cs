using Prodfy.Helpers;
using Prodfy.Models;
using System;

namespace Prodfy.Services.Repository
{
    public class MonitCodArvRepository
    {
        private readonly DataBase dataBase;

        public MonitCodArvRepository()
        {
            dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var totalRegistro = dataBase._conexao.Table<Monit_Cod_Arv>().Count();

            if (totalRegistro > 0)
                return totalRegistro;

            return 0;
        }

        public void Adicionar(Monit_Cod_Arv monit_Cod_Arv)
        {
            try
            {
                dataBase._conexao.Insert(monit_Cod_Arv);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Monit_Cod_Arv>();
        }
    }
}
