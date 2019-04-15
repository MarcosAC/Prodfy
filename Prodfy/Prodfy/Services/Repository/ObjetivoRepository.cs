using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class ObjetivoRepository : IRepository<Objetivo>
    {
        public void Adicionar(Objetivo entidade)
        {
            throw new NotImplementedException();
        }

        public TableQuery<Objetivo> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Objetivo entidade)
        {
            throw new NotImplementedException();
        }

        public Objetivo ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Objetivo> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
