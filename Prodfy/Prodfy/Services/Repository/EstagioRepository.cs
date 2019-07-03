using Prodfy.Helpers;
using Prodfy.Models;
using Prodfy.Services.Dialog;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodfy.Services.Repository
{
    public class EstagioRepository : IRepository<Estagio>
    {
        private DataBase dataBase;

        private readonly IDialogService dialogService;

        public EstagioRepository()
        {
            dataBase = new DataBase();

            dialogService = new DialogService();
        }

        public void Adicionar(Estagio estagio)
        {
            try
            {
                dataBase._conexao.Insert(estagio);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public async Task<List<Estagio>> ListaLocalEstagio(int pontoControleId, int loteId, int mudaId, DateTime dataEstaq)
        {
            string query = "SELECT distinct " +
                                "PCE.produto_id, " +
                                "PCE.ponto_controle_id, " +
                                "PCE.estagio_id, PCE.codigo, " +
                                "PCE.titulo, " +
                                "PCE.unidade, " +
                                "PCE.maturacao, " +
                                "PCE.maturacao_seg, " +
                                "PCE.ind_alertas, " +
                                "PCE.ordem " +
                           "FROM Estagio PCE " +
                           "INNER JOIN Inv_Item I1 ON I1.ponto_controle_id = PCE.ponto_controle_id AND I1.estagio_id = PCE.estagio_id " +
                           "WHERE I1.lote_id = " + "'" + loteId + "'" + " " +
                           "AND I1.ponto_controle_id = " + "'" + pontoControleId + "'" + " " +
                           "AND I1.muda_id = " + "'" + mudaId + "'" + " " +
                           "AND date(I1.data_estaq) = " + "'" + dataEstaq + "'" + " " +
                           "AND (IFNULL((SELECT sum(I2.qtde) " +
                                         "FROM Inv_Item I1 " +
                                         "INNER JOIN Inv I2 ON I2.inv_item_id = I1.inv_item_id " +
                                         "WHERE I1.ponto_controle_id = PCE.ponto_controle_id " +
                                         "AND I1.estagio_id = PCE.estagio_id),0) - " +
                           "IFNULL((SELECT sum(IE.qtde_amostragem) " +
                                    "FROM Inv_Evo IE " +
                                    "INNER JOIN Inv_Item I1 ON I1.inv_item_id = IE.inv_item_id " +
                                    "WHERE IE.ponto_controle_ori_id = PCE.ponto_controle_id " +
                                    "AND IE.estagio_ori_id = PCE.estagio_id),0) ) > 0 " +
                           "ORDER BY PCE.ordem";

            List<Estagio> listaLocalEstagio = new List<Estagio>();

            try
            {
                var dados = dataBase._conexao.Query<Estagio>(query);

                for (int i = 0; i < dados.Count; i++)
                {
                    listaLocalEstagio.Add(dados[i]);
                }
            }
            catch (Exception erro)
            {
                await dialogService.AlertAsync("Erro", erro.ToString(), "Ok");
            }

            return listaLocalEstagio;
        }

        public async Task<string> LocalQuantidadeMudasNoEstagio(int estagioId, int loteId, int mudaId, DateTime dataEstaq)
        {
            string query = "SELECT " +
                                "IFNULL(I2.qtde,0) " +
                           "FROM Inv_Item AA " +
                           "INNER JOIN " +
                                "Inv I2 ON I2.inv_item_id = AA.inv_item_id " +
                           "WHERE AA.estagio_id = " + "'" + estagioId + "'" + " " +
                           "AND AA.lote_id = " + "'" + loteId + "'" + " " +
                           "AND AA.muda_id = " + "'" + mudaId + "'" + " " +
                           "AND date(AA.data_estaq) =" + "'" + mudaId + "'" + " " +
                           "LIMIT 1";

            string quantidade = string.Empty;

            try
            {
                List<Inv> dados = dataBase._conexao.Query<Inv>(query);

                for (int i = 0; i < dados.Count; i++)
                    quantidade = dados[0].ToString();
            }
            catch (Exception erro)
            {
                await dialogService.AlertAsync("Erro", erro.ToString(), "Ok");
            }

            return quantidade;
        }

        public TableQuery<Estagio> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Estagio>();
        }

        public void Editar(Estagio entidade)
        {
            throw new NotImplementedException();
        }

        public Estagio ObterDados()
        {
            throw new NotImplementedException();
        }

        public Estagio ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(int codigo)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public List<Estagio> ObterTodos()
        {
            return dataBase._conexao.Table<Estagio>().ToList();
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
