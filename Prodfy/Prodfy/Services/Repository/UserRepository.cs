﻿using Prodfy.Helpers;
using Prodfy.Models;
using Prodfy.Services.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class UserRepository : IUserRepository
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

        public void DeletarTodos()
        {
            _dataBase._conexao.Execute("Delete From User");
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

        public List<User> ObterDispositivoId()
        {
            return _dataBase._conexao.Query<User>("SELECT disp_id FROM User LIMIT 1");
        }
    }
}
