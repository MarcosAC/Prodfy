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
            _dataBase._conexao.Insert(user);
        }

        public void Deletar(User user)
        {
            _dataBase._conexao.Delete(user);
        }

        public void Editar(User user)
        {
            _dataBase._conexao.Update(user);
        }

        public User ObterPorId(int id)
        {
            return _dataBase._conexao.Table<User>().FirstOrDefault(u => u.idUser == id);
        }

        public List<User> ObterTodos()
        {
            return _dataBase._conexao.Table<User>().OrderBy(u => u.idUser).ToList();
        }

        //IQueryable<User> IRepository<User>.ObterPorId(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
