using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
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
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }
               
        public void Deletar()
        {
            _dataBase._conexao.Execute("Delete From User");
        }

        public void Editar(User user)
        {
            try
            {
                _dataBase._conexao.Update(user);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }            
        }

        public User ObterDados()
        {
            if (_dataBase._conexao.Table<User>().Count() > 0)
            {
                var dadosUsuario = _dataBase._conexao.Table<User>().First();
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

        public TableQuery<User> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public User ObterDadosPorId(string id)
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
