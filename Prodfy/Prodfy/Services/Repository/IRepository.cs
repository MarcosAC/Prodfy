using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public interface IRepository<T> where T : class
    {
        void Adicionar(T entidade);
        void Deletar(T entidade);
        void Editar(T entidade);
        //IQueryable<T> ObterPorId(int id);
        List<T> ObterTodos();
    }
}
