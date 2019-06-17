using Prodfy.Helpers;
using Prodfy.Models;
using Prodfy.Services.Dialog;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodfy.Services.Repository
{
    public class PontoControleRepository : IRepository<Ponto_Controle>
    {
        private DataBase dataBase;

        private readonly IDialogService dialogService;

        public PontoControleRepository()
        {
            dataBase = new DataBase();

            dialogService = new DialogService();
        }

        public void Adicionar(Ponto_Controle ponto_Controle)
        {
            try
            {
                dataBase._conexao.Insert(ponto_Controle);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public async Task<List<Ponto_Controle>> ListaDadosPontoControle(int loteId, int mudaId, DateTime dataEstaq)
        {            
            string query = "SELECT distinct " +
                              "PC.produto_id, " +
                              "PC.ponto_controle_id, " +
                              "PC.codigo, " +
                              "PC.titulo, " +
                              "PC.unidade, " +
                              "PC.maturacao, " +
                              "PC.maturacao_seg, " +
                              "PC.ind_alertas, " +
                              "PC.ordem " +
                           "FROM Ponto_Controle PC " +
                           "INNER JOIN Inv_Item I1 ON I1.ponto_controle_id = PC.ponto_controle_id " +
                           "WHERE I1.lote_id = " + "'" + loteId + "'" +
                           "AND I1.muda_id = " + "'" + mudaId + "'" +
                           "AND date(I1.data_estaq) = " + "'" + dataEstaq + "'" +
                           "AND (IFNULL(" +
                                    "(SELECT " +
                                        "sum(I2.qtde) FROM Inv_Item I1 " +
                                    "INNER JOIN Inv I2 ON I2.inv_item_id = I1.inv_item_id " +
                                    "WHERE I1.ponto_controle_id = PC.ponto_controle_id),0) - " +
                                    "IFNULL(" +
                                        "(SELECT sum(IE.qtde_amostragem) " +
                                        "FROM Inv_Evo IE INNER JOIN Inv_Item I1 ON I1.inv_item_id = IE.inv_item_id " +
                                        "WHERE IE.ponto_controle_ori_id = PC.ponto_controle_id),0) ) > 0 " +
                           "ORDER BY PC.ordem";

            List<Ponto_Controle> listaPontoControles = new List<Ponto_Controle>();

            try
            {
                var dados = dataBase._conexao.Query<Ponto_Controle>(query);

                for (int i = 0; i < dados.Count; i++)
                    listaPontoControles.Add(dados[i]);
            }
            catch (Exception erro)
            {
                await dialogService.AlertAsync("Erro", erro.ToString(), "Ok");
            }

            return listaPontoControles; ;
        }

        public TableQuery<Ponto_Controle> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Ponto_Controle>();
        }

        public void Editar(Ponto_Controle entidade)
        {
            throw new NotImplementedException();
        }

        public Ponto_Controle ObterDados()
        {
            throw new NotImplementedException();
        }

        public Ponto_Controle ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(int id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(int id, string codigo)
        {
            throw new NotImplementedException();
        }

        public List<Ponto_Controle> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
