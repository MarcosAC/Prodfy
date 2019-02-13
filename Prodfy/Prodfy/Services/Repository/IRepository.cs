using SQLite;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public interface IRepository<T> where T : class
    {
        void Adicionar(T entidade);
        void Deletar(T entidade);
        void Editar(T entidade);
        T ObterDados();        
        List<T> ObterTodos();
        TableQuery<T> AsQueryable();
        //IQueryable<T> ObterPorId(int id);
    }
}
