using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class InventarioRepository : IRepository<Contagem>
    {
        public void Adicionar(Contagem entidade)
        {
            throw new NotImplementedException();
        }

        public TableQuery<Contagem> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar(Contagem entidade)
        {
            throw new NotImplementedException();
        }

        public void Editar(Contagem entidade)
        {
            throw new NotImplementedException();
        }

        public Contagem ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Contagem> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
