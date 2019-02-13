﻿using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class AtividadeRepository : IRepository<Atividade>
    {
        private DataBase _dataBase;

        public AtividadeRepository()
        {
            _dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var total = _dataBase._conexao.Table<Atividade>().Count();

            if (total > 0)
                return total;

            return 0;
        }

        public void Adicionar(Atividade entidade)
        {
            throw new NotImplementedException();
        }

        public TableQuery<Atividade> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar(Atividade entidade)
        {
            throw new NotImplementedException();
        }

        public void Editar(Atividade entidade)
        {
            throw new NotImplementedException();
        }

        public Atividade ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Atividade> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
