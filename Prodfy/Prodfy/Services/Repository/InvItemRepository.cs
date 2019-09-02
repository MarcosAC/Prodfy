using Prodfy.Helpers;
using Prodfy.Models;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class InvItemRepository : IRepository<Inv_Item>
    {
        DataBase dataBase;

        public InvItemRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Inv_Item inv_item)
        {
            try
            {
                dataBase._conexao.Insert(inv_item);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public List<Inv_Item> ObterDataEstaquemento(int loteId/*, int mudaId, int qualidadeId*/)
        {
            //var where = string.Empty;
            //var cap = string.Empty;

            //var query = "SELECT " +
            //                "distinct strftime('%d/%m/%Y', data_estaq), " +
            //            "IFNULL(abs(Cast((JulianDay(data_estaq) - JulianDay('now')) As Integer)),0) " +
            //            "FROM " +
            //                "Inv_Item";

            //var query = "SELECT " +
            //                "data_estaq " +                        
            //            " FROM " +
            //                "Inv_Item";            

            //if (loteId > 0)
            //    if (!string.IsNullOrEmpty(where))
            //        cap = " AND ";
            //where += $"{cap}lote_id = {loteId}";

            //if (mudaId > 0)
            //    if (!string.IsNullOrEmpty(where))
            //        cap = " AND ";
            //where += $"{cap}AA.muda_id = {mudaId}";

            //if (qualidadeId > 0)
            //    if (!string.IsNullOrEmpty(where))
            //        cap = " AND ";
            //where += $"{cap}AA.qualidade_id = {qualidadeId}";

            //if (!string.IsNullOrEmpty(where))
            //    where = $" WHERE {where}";

            //query += where;
            //query += " GROUP BY data_estaq";
            //query += " ORDER BY 1";                        

            //foreach (var item in listaDatasEstaquementos)
            //{
            //    lista.Add(listaDatasEstaquementos[0].data_estaq.ToString());
            //    lista.Add(listaDatasEstaquementos[1].ToString());

            //    var info = lista[0];
            //    int idade = int.Parse(lista[1]);

            //    if (idade == 0 || idade > 1)
            //        info = $"{info} {idade.ToString()}";
            //    else
            //        info = $"{info} {idade.ToString()}";
            //}

            var query = "SELECT data_estaq FROM Inv_Item Where lote_id = " + loteId;

            //var datasEstaqueamentos = dataBase._conexao.Query<Inv_Item>(query);
            return dataBase._conexao.Query<Inv_Item>(query);
            //List<string> listaDataEstaqueamento = new List<string>();

            //foreach (var item in datasEstaqueamentos)
            //{
            //    listaDataEstaqueamento.Add(item.data_estaq.ToString());
            //}

            //return listaDataEstaqueamento;
        }

        public SQLite.TableQuery<Inv_Item> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Inv_Item>();
        }

        public void Editar(Inv_Item entidade)
        {
            throw new NotImplementedException();
        }

        public Inv_Item ObterDados()
        {
            throw new NotImplementedException();
        }

        public Inv_Item ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(int id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public List<Inv_Item> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
