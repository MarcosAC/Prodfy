using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class InvRepository : IRepository<Inv>
    {
        DataBase dataBase;

        public InvRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Inv inv)
        {
            try
            {
                dataBase._conexao.Insert(inv);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public List<QuantidadeMudasEstagio> ObterEstoqueViveiroQuantidadeMudasNoEstoque(int loteId,
                                                                     int mudaId,
                                                                     int qualidadeId,
                                                                     int estagioId,
                                                                     string dataEstaqueamento = null,
                                                                     string dataSelecao = null)
        {
            string query = "SELECT IFNULL(sum(I2.qtde),0) FROM Inv_Item AA INNER JOIN Inv I2 ON I2.inv_item_id = AA.inv_item_id ";

            string where = string.Empty;
            string cap = string.Empty;

            if (estagioId > 0)
            {
                if (!string.IsNullOrEmpty(where))
                    cap = " AND ";

                where += $"{cap}estagio_id = {estagioId} ";
            }

            if (loteId > 0)
            {
                if (!string.IsNullOrEmpty(where))
                    cap = " AND ";

                where += $"{cap}AA.lote_id = {loteId} ";
            }

            if (mudaId > 0)
            {
                if (!string.IsNullOrEmpty(where))
                    cap = " AND ";

                where += $"{cap}AA.muda_id = {mudaId} ";
            }

            if (qualidadeId > 0)
            {
                if (!string.IsNullOrEmpty(where))
                    cap = " AND ";

                where += $"{cap}AA.qualidade_id = {qualidadeId} ";
            }

            if (!string.IsNullOrEmpty(where))
                where = $"WHERE {where}";

            query += where;

            var dadosEstoqueViveiroQuantidadeMudasNoEstoque = dataBase._conexao.Query<QuantidadeMudasEstagio>(query);

            if (!string.IsNullOrEmpty(dataEstaqueamento) && !string.IsNullOrEmpty(dataSelecao))
            {
                var listaEstoqueViveiroQuantidadeMudasNoEstoque = new List<QuantidadeMudasEstagio>();

                foreach (QuantidadeMudasEstagio item in dadosEstoqueViveiroQuantidadeMudasNoEstoque)
                {
                    if (item.data_estaq.Equals(Convert.ToDateTime(dataEstaqueamento)) && item.data_selecao.Equals(Convert.ToDateTime(dataSelecao)))
                    {
                        listaEstoqueViveiroQuantidadeMudasNoEstoque.Add(item);
                    }
                }

                return listaEstoqueViveiroQuantidadeMudasNoEstoque;
            }
            else if (!string.IsNullOrEmpty(dataEstaqueamento))
            {
                var listaEstoqueViveiroQuantidadeMudasNoEstoque = new List<QuantidadeMudasEstagio>();

                foreach (QuantidadeMudasEstagio item in dadosEstoqueViveiroQuantidadeMudasNoEstoque)
                {
                    if (item.data_estaq.Equals(Convert.ToDateTime(dataEstaqueamento)))
                    {
                        listaEstoqueViveiroQuantidadeMudasNoEstoque.Add(item);
                    }
                }

                return listaEstoqueViveiroQuantidadeMudasNoEstoque;
            }
            else if (!string.IsNullOrEmpty(dataSelecao))
            {
                var listaEstoqueViveiroQuantidadeMudasNoEstoque = new List<QuantidadeMudasEstagio>();

                foreach (QuantidadeMudasEstagio item in dadosEstoqueViveiroQuantidadeMudasNoEstoque)
                {
                    if (item.data_selecao.Equals(Convert.ToDateTime(dataSelecao)))
                    {
                        listaEstoqueViveiroQuantidadeMudasNoEstoque.Add(item);
                    }
                }

                return listaEstoqueViveiroQuantidadeMudasNoEstoque;
            }

            return dadosEstoqueViveiroQuantidadeMudasNoEstoque;
        }

        public TableQuery<Inv> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Inv>();
        }

        public void Editar(Inv entidade)
        {
            throw new NotImplementedException();
        }

        public Inv ObterDados()
        {
            throw new NotImplementedException();
        }

        public Inv ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterMudaInfo(int id)
        {
            throw new NotImplementedException();
        }

        public string ObterLoteInfo(string codigo)
        {
            throw new NotImplementedException();
        }

        public List<Inv> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
