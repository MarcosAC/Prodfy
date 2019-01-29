using Prodfy.Helpers;
using Prodfy.Models;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    class UserRepository : IRepository<User>
    {
        //DataBase _dataBase;
        //private SQLiteConnection _conexao;

        //public UserRepository()
        //{
        //    //_dataBase = new DataBase();

        //    //var dependencyService = DependencyService.Get<IConexaoBancoDados>();
        //    //string stringConexao = dependencyService.Conexao("ProdfyPlantas.sqlite");
        //}

        public void Adicionar(User user)
        {
            //_dataBase.Adicionar(user);
            //_conexao.Insert(user);
            DataBase._conexao.Insert(user);
        }

        public void Deletar(User user)
        {
            //_dataBase.Deletar(user);
            DataBase._conexao.Delete(user);
        }

        public void Editar(User user)
        {
            //_dataBase.Editar(user);
            DataBase._conexao.Update(user);
        }

        public User ObterPorId(int id)
        {
            // return _dataBase.ObterPorId(id);
            return DataBase._conexao.Table<User>().FirstOrDefault(u => u.idUser == id);
        }

        public List<User> ObterTodos()
        {
            //throw new NotImplementedException();
            return DataBase._conexao.Table<User>().OrderBy(u => u.idUser).ToList();
        }

        //IQueryable<User> IRepository<User>.ObterPorId(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
