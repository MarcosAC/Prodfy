using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class ColaboradorRepository : IRepository<Colaborador>
    {
        public void Adicionar(Colaborador entidade)
        {
            throw new NotImplementedException();
        }

        public TableQuery<Colaborador> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Colaborador entidade)
        {
            throw new NotImplementedException();
        }

        public Colaborador ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Colaborador> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
