using Prodfy.Helpers;
using Prodfy.Models;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class UserRepository : IRepository<User>
    {
        private DataBase _dataBase;

        public UserRepository()
        {            
            _dataBase = new DataBase();
        }

        public void Adicionar(User user)
        {
            try
            {
                _dataBase._conexao.Insert(user);                
            }
            catch (System.Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }
               
        public void Deletar(User user)
        {
            _dataBase._conexao.Delete(user);
        }

        public void Editar(User user)
        {
            _dataBase._conexao.Update(user);
        }

        public User ObterDados()
        {
            if (_dataBase._conexao.Table<User>().Count() > 0)
            {
                var dadosUsuario = _dataBase._conexao.Table<User>().FirstOrDefault();
                return dadosUsuario;
            }

            return null;
        }

        public User ObterPorId(int id)
        {
            return _dataBase._conexao.Table<User>().FirstOrDefault(u => u.idUser == id);
        }

        public List<User> ObterTodos()
        {
            return _dataBase._conexao.Table<User>().OrderBy(u => u.idUser).ToList();
        }

        public void DeletarTodasTabelas()
        {
            _dataBase.DeletaTodasTabelas();
        }
    }
}
