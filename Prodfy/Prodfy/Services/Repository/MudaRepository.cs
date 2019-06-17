using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class MudaRepository : IRepository<Muda>
    {
        private DataBase dataBase;

        public MudaRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Muda muda)
        {
            try
            {
                dataBase._conexao.Insert(muda);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public TableQuery<Muda> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Muda>();
        }

        public void Editar(Muda entidade)
        {
            throw new NotImplementedException();
        }

        public Muda ObterDados()
        {
            var dadosMuda = dataBase._conexao.Table<Muda>().FirstOrDefault();
            return dadosMuda;
        }

        public Muda ObterDadosPorId(int id)
        {
            var dadosMuda = dataBase._conexao.Table<Muda>().FirstOrDefault(m => m.muda_id == id);
            return dadosMuda;
        }

        public Muda ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(int mudaId)
        {
            var dadosMuda = dataBase._conexao.Table<Muda>().FirstOrDefault(m => m.muda_id == mudaId);

            var mudaInfo = new
            {
                dadosMuda.muda_id,
                dadosMuda.nome_interno,
                dadosMuda.nome,
                dadosMuda.especie_nome_comum,
                dadosMuda.especie_nome_especie,
                dadosMuda.especie_nome_cientifico,
                dadosMuda.origem,
                dadosMuda.viveiro,
                dadosMuda.canaletao,
                dadosMuda.linha,
                dadosMuda.coluna,
                dadosMuda.qtde
            };

            string ret = string.Empty;

            if (mudaInfo.muda_id != 0)
            {
                ret = $"1||{mudaInfo.muda_id}|" +
                      $"{mudaInfo.nome_interno}|" +
                      $"{mudaInfo.nome}|" +
                      $"{mudaInfo.especie_nome_comum}|" +
                      $"{mudaInfo.especie_nome_especie}|" +
                      $"{mudaInfo.especie_nome_cientifico}|" +
                      $"{mudaInfo.origem}|" +
                      $"{mudaInfo.viveiro}|" +
                      $"{mudaInfo.canaletao}|" +
                      $"{mudaInfo.linha}|" +
                      $"{mudaInfo.coluna}|" +
                      $"{mudaInfo.qtde}|";
            }
            else
            {
                ret = "0|Registro não encontrado!|";
            }

            return ret;
        }

        public string ObterInformacoesParaIdentificacao(int id, string codigo)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public List<Muda> ObterTodos()
        {
            var listaMuda = dataBase._conexao.Table<Muda>().ToList();
            return listaMuda;
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
