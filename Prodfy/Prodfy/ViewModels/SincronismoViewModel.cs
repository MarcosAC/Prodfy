using Prodfy.Models;
using Prodfy.Services.API;
using Prodfy.Services.Dialog;
using Prodfy.Services.Repository;
using Prodfy.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class SincronismoViewModel : BaseViewModel
    {
        #region Variaveis
        private Sincronismo sincronismo = null;
        private User user = null;
        private Produto produto = null;
        private Objetivo objetivo = null;
        private Ponto_Controle ponto_controle = null;
        private Estagio estagio = null;
        private Muda muda = null;
        private Lote lote = null;
        private Perda_Motivo perda_motivo = null;
        private Monit monit = null;
        private Monit_Cod_Arv monit_cod_arv = null;
        private Monit_Parcela monit_parcela = null;
        private Colaborador colaborador = null;
        private Lista_Atv lista_atv = null;
        private Qualidade qualidade = null;
        private Exped_Dest exped_dest = null;
        private Estaq estaq = null;
        #endregion

        private string dataSincronizacao = "Não Sincronizado!";

        private readonly IDialogService _dialogService;

        DadosSincronismoService dadosSincronismo = new DadosSincronismoService();

        #region Implementação Repositorios

        private UserRepository userRepository;
        private AtividadeRepository atividadeRepository;
        private InventarioRepository inventarioRepository;
        private PerdaRepository perdaRepository;
        private HistoricoRepository historicoRepository;
        private MovimentacaoRepository movimentacaoRepository;
        private OcorrenciaRepository ocorrenciaRepository;
        private MedicaoRepository medicaoRepository;
        private ExpedicaoRepository expedicaoRepository;
        private ProdutoRepository produtoRepository;
        private ObjetivoRepository objetivoRepository;
        private PontoControleRepository pontoControleRepository;
        private EstagioRepository estagioRepository;
        private MudaRepository mudaRepository;
        private LoteRepository loteRepository;
        private PerdaMotivoRepository perdaMotivoRepository;
        private MonitRepository monitRepository;
        private MonitCodArvRepository monitCodArvRepository;
        private MonitParcelaRepository monitParcelaRepository;        
        private ColaboradorRepository colaboradorRepository;
        private ListaAtvRepository listaAtvRepository;
        private QualidadeRepository qualidadeRepository;
        private ExpedDestRepository expedDestRepository;
        private EstaqRepository estaqRepository;

        #endregion

        public SincronismoViewModel()
        {
            _dialogService = new DialogService();

            userRepository = new UserRepository();
            atividadeRepository = new AtividadeRepository();
            inventarioRepository = new InventarioRepository();
            perdaRepository = new PerdaRepository();
            historicoRepository = new HistoricoRepository();
            movimentacaoRepository = new MovimentacaoRepository();
            ocorrenciaRepository = new OcorrenciaRepository();
            medicaoRepository = new MedicaoRepository();
            expedicaoRepository = new ExpedicaoRepository();
            produtoRepository = new ProdutoRepository();
            objetivoRepository = new ObjetivoRepository();
            pontoControleRepository = new PontoControleRepository();
            estagioRepository = new EstagioRepository(); 
            mudaRepository = new MudaRepository();
            loteRepository = new LoteRepository();
            perdaMotivoRepository = new PerdaMotivoRepository();
            monitRepository = new MonitRepository();
            monitCodArvRepository = new MonitCodArvRepository();
            monitParcelaRepository = new MonitParcelaRepository();
            colaboradorRepository = new ColaboradorRepository();
            listaAtvRepository = new ListaAtvRepository();
            qualidadeRepository = new QualidadeRepository();
            expedDestRepository = new ExpedDestRepository();
            estaqRepository = new EstaqRepository();
        }

        #region Propriedades sincronismo
       
        private string _dhtLastSincr;
        public string DhtLastSincr { get => _dhtLastSincr = dataSincronizacao; }

        public int? IndAtv { get => sincronismo?.ind_atv; }
        public int? IndInv { get => sincronismo?.ind_inv; }
        public int? IndPer { get => sincronismo?.ind_per; }
        public int? IndHist { get => sincronismo?.ind_hist; }
        public int? IndMov { get => sincronismo?.ind_mov; }
        public int? IndOco { get => sincronismo?.ind_oco; }
        public int? IndMnt { get => sincronismo?.ind_mnt; }
        public int? IndExp { get => sincronismo?.ind_mnt; }
        public int? IndIdent { get => sincronismo?.ind_mnt; }

        #endregion

        private bool CanExecuteSincronizarCommand()
        {
            return LoginViewModel.estaLogado;
        }

        private Command _sincronozarCommand;
        public Command SincronizarCommand =>
            _sincronozarCommand ?? (_sincronozarCommand = new Command(ExecuteSincronizarCommand, CanExecuteSincronizarCommand));

        private async void ExecuteSincronizarCommand()
        {
            IsBusy = true;

            if (VerificaConexaoInternet.VerificaConexao())
            {
                if (UploadDados().Count >= 0)
                {

                    var dadosResponse = await dadosSincronismo.UploadDadosParaSincronisar(userRepository.ObterDados().app_key, userRepository.ObterDados().lang, UploadDados());

                    try
                    {
                        var dadosUser = userRepository.ObterDados();

                        var _dadosSincronismo = await dadosSincronismo.ObterDadosSincronismo(dadosUser.app_key, dadosUser.lang);

                        if (dadosResponse.sinc_stat == 1)
                        {
                            #region Dados Usuario                            

                            user = new User
                            {
                                disp_id = dadosUser.disp_id,
                                idUser = dadosUser.idUser,
                                sinc_url = dadosUser.sinc_url,
                                lang = dadosUser.lang,
                                app_key = dadosUser.app_key,
                                disp_num = _dadosSincronismo.disp_num,
                                senha = _dadosSincronismo.senha,
                                nome = _dadosSincronismo.nome,
                                sobrenome = _dadosSincronismo.sobrenome,
                                empresa = _dadosSincronismo.empresa,
                                autosinc = _dadosSincronismo.autosinc,
                                autosinc_time = _dadosSincronismo.autosinc_time,
                                ind_ident = _dadosSincronismo.ind_ident,
                                ind_inv = _dadosSincronismo.ind_inv,
                                ind_per = _dadosSincronismo.ind_per,
                                ind_hist = _dadosSincronismo.ind_hist,
                                ind_mov = _dadosSincronismo.ind_mov,
                                ind_mnt = _dadosSincronismo.ind_mnt,
                                ind_exp = _dadosSincronismo.ind_exp,
                                ind_atv = _dadosSincronismo.ind_atv,
                                uso_liberado = _dadosSincronismo.uso_liberado,
                                dth_last_sincr = _dadosSincronismo.sinc_date
                            };

                            userRepository.Editar(user);

                            #endregion

                            #region Indicadores

                            if (dadosResponse.ind_atv != null) // Atividade
                            {
                                if (dadosResponse.ind_atv == 1)
                                    atividadeRepository.DeletarTodos();
                            }

                            if (dadosResponse.ind_mov != null) // Evolução
                            {
                                if (dadosResponse.ind_mov == 1)
                                    movimentacaoRepository.DeletarTodos();
                            }

                            if (dadosResponse.ind_exp != null) // Expedição
                            {
                                if (dadosResponse.ind_exp == 1)
                                    expedicaoRepository.DeletarTodos();
                            }

                            if (dadosResponse.ind_hist != null) // Historico
                            {
                                if (dadosResponse.ind_hist == 1)
                                    historicoRepository.DeletarTodos();
                            }

                            if (dadosResponse.ind_inv != null) // Inventario
                            {
                                if (dadosResponse.ind_inv == 1)
                                    inventarioRepository.DeletarTodos();
                            }

                            if (dadosResponse.ind_mnt != null) // Medição
                            {
                                if (dadosResponse.ind_mnt == 1)
                                    medicaoRepository.DeletarTodos();
                            }

                            if (dadosResponse.ind_oco != null) // Ocorrencia
                            {
                                if (dadosResponse.ind_oco == 1)
                                    ocorrenciaRepository.DeletarTodos();
                            }

                            if (dadosResponse.ind_per != null) // Perda
                            {
                                if (dadosResponse.ind_per == 1)
                                    perdaRepository.DeletarTodos();
                            }

                            #endregion

                            #region Dados Sincronia

                            // Produto
                            for (int i = 0; i < _dadosSincronismo.produto.Length; i++)
                            {
                                produto = new Produto
                                {
                                    idProduto = int.Parse(_dadosSincronismo.produto[i].idProduto.ToString()),
                                    produto_id = _dadosSincronismo.produto[i].produto_id,
                                    titulo = _dadosSincronismo.produto[i].titulo,
                                    last_update = _dadosSincronismo.produto[i].last_update,
                                    ind_sinc = int.Parse(_dadosSincronismo.produto[i].ind_sinc.ToString())
                                };

                                produtoRepository.Adicionar(produto);
                            }

                            // Objetivo
                            for (int i = 0; i < _dadosSincronismo.objetivo.Length; i++)
                            {
                                objetivo = new Objetivo
                                {
                                    idObjetivo = int.Parse(_dadosSincronismo.objetivo[i].idObjetivo.ToString()),
                                    objetivo_id = _dadosSincronismo.objetivo[i].objetivo_id,
                                    titulo = _dadosSincronismo.objetivo[i].titulo,
                                    last_update = _dadosSincronismo.objetivo[i].last_update,
                                    ind_sinc = int.Parse(_dadosSincronismo.objetivo[i].ind_sinc.ToString())
                                };

                                objetivoRepository.Adicionar(objetivo);
                            }

                            // Ponto Controle
                            for (int i = 0; i < _dadosSincronismo.ponto_controle.Length; i++)
                            {
                                ponto_controle = new Ponto_Controle
                                {
                                    idPonto_Controle = int.Parse(_dadosSincronismo.ponto_controle[i].idPonto_Controle.ToString()),
                                    ponto_controle_id = _dadosSincronismo.ponto_controle[i].ponto_controle_id,
                                    produto_id = _dadosSincronismo.ponto_controle[i].produto_id,
                                    codigo = _dadosSincronismo.ponto_controle[i].codigo,
                                    titulo = _dadosSincronismo.ponto_controle[i].titulo,
                                    maturacao = _dadosSincronismo.ponto_controle[i].maturacao,
                                    unidade = _dadosSincronismo.ponto_controle[i].unidade,
                                    maturacao_seg = _dadosSincronismo.ponto_controle[i].maturacao_seg,
                                    ind_alertas = _dadosSincronismo.ponto_controle[i].ind_alertas,
                                    last_update = _dadosSincronismo.ponto_controle[i].last_update,
                                    ind_sinc = int.Parse(_dadosSincronismo.ponto_controle[i].ind_sinc.ToString())
                                };

                                pontoControleRepository.Adicionar(ponto_controle);
                            }

                            //Estagio
                            for (int i = 0; i < _dadosSincronismo.estagio.Length; i++)
                            {
                                estagio = new Estagio
                                {
                                    idEstagio = int.Parse(_dadosSincronismo.estagio[i].idEstagio.ToString()),
                                    estagio_id = _dadosSincronismo.estagio[i].estagio_id,
                                    produto_id = _dadosSincronismo.estagio[i].produto_id,
                                    ponto_controle_id = _dadosSincronismo.estagio[i].ponto_controle_id,
                                    codigo = _dadosSincronismo.estagio[i].codigo,
                                    titulo = _dadosSincronismo.estagio[i].titulo,
                                    maturacao = _dadosSincronismo.estagio[i].maturacao,
                                    unidade = _dadosSincronismo.estagio[i].unidade,
                                    maturacao_seg = _dadosSincronismo.estagio[i].maturacao_seg,
                                    ind_alertas = _dadosSincronismo.estagio[i].ind_alertas,
                                    last_update = _dadosSincronismo.estagio[i].last_update,
                                    ind_sinc = int.Parse(_dadosSincronismo.estagio[i].ind_sinc.ToString())
                                };

                                estagioRepository.Adicionar(estagio);
                            }

                            //Muda
                            for (int i = 0; i < _dadosSincronismo.muda.Length; i++)
                            {
                                muda = new Muda
                                {
                                    idMuda = int.Parse(_dadosSincronismo.muda[i].idMuda.ToString()),
                                    muda_id = _dadosSincronismo.muda[i].muda_id,
                                    nome_interno = _dadosSincronismo.muda[i].nome_interno,
                                    nome = _dadosSincronismo.muda[i].nome,
                                    especie_nome_comum = _dadosSincronismo.muda[i].especie_nome_comum,
                                    especie_nome_especie = _dadosSincronismo.muda[i].especie_nome_especie,
                                    especie_nome_cientifico = _dadosSincronismo.muda[i].especie_nome_cientifico,
                                    origem = _dadosSincronismo.muda[i].origem,
                                    viveiro = _dadosSincronismo.muda[i].viveiro,
                                    canaletao = _dadosSincronismo.muda[i].canaletao,
                                    linha = _dadosSincronismo.muda[i].linha,
                                    coluna = _dadosSincronismo.muda[i].coluna,
                                    qtde = _dadosSincronismo.muda[i].qtde,
                                    last_update = _dadosSincronismo.muda[i].last_update,
                                    ind_sinc = int.Parse(_dadosSincronismo.muda[i].ind_sinc.ToString())
                                };

                                mudaRepository.Adicionar(muda);
                            }

                            // Lote
                            for (int i = 0; i < _dadosSincronismo.lote.Length; i++)
                            {
                                lote = new Lote
                                {
                                    idLote = int.Parse(_dadosSincronismo.lote[i].idLote.ToString()),
                                    lote_id = _dadosSincronismo.lote[i].lote_id,
                                    produto_id = _dadosSincronismo.lote[i].produto_id,
                                    codigo = _dadosSincronismo.lote[i].codigo,
                                    objetivo = _dadosSincronismo.lote[i].objetivo,
                                    cliente = _dadosSincronismo.lote[i].cliente,
                                    last_update = _dadosSincronismo.lote[i].last_update,
                                    ind_sinc = int.Parse(_dadosSincronismo.lote[i].ind_sinc.ToString())
                                };

                                loteRepository.Adicionar(lote);
                            }

                            // Perda Motivo
                            for (int i = 0; i < _dadosSincronismo.perda_motivo.Length; i++)
                            {
                                perda_motivo = new Perda_Motivo
                                {
                                    idPerda_Motivo = int.Parse(_dadosSincronismo.perda_motivo[i].idPerda_Motivo.ToString()),
                                    perda_motivo_id = _dadosSincronismo.perda_motivo[i].perda_motivo_id,
                                    motivo = _dadosSincronismo.perda_motivo[i].motivo,
                                    last_update = _dadosSincronismo.perda_motivo[i].last_update,
                                    ind_sinc = int.Parse(_dadosSincronismo.perda_motivo[i].ind_sinc.ToString())
                                };

                                perdaMotivoRepository.Adicionar(perda_motivo);
                            }

                            // Monit
                            for (int i = 0; i < _dadosSincronismo.monit.Length; i++)
                            {
                                monit = new Monit
                                {
                                    idMonit = int.Parse(_dadosSincronismo.monit[i].idMonit.ToString()),
                                    monit_id = _dadosSincronismo.monit[i].monit_id,
                                    codigo = _dadosSincronismo.monit[i].codigo,
                                    produto_id = _dadosSincronismo.monit[i].produto_id,
                                    objetivo_id = _dadosSincronismo.monit[i].objetivo_id,
                                    data_plantio = _dadosSincronismo.monit[i].data_plantio,
                                    esp_linha = _dadosSincronismo.monit[i].esp_linha,
                                    esp_plantas = _dadosSincronismo.monit[i].esp_plantas,
                                    projeto = _dadosSincronismo.monit[i].projeto,
                                    talhao = _dadosSincronismo.monit[i].talhao,
                                    num_trat = _dadosSincronismo.monit[i].num_trat,
                                    num_rep = _dadosSincronismo.monit[i].num_rep,
                                    pi_lat_g = _dadosSincronismo.monit[i].pi_lat_g,
                                    pi_lat_m = _dadosSincronismo.monit[i].pi_lat_m,
                                    pi_lat_s = _dadosSincronismo.monit[i].pi_lat_s,
                                    pi_lat_d = _dadosSincronismo.monit[i].pi_lat_d,
                                    pi_lat = _dadosSincronismo.monit[i].pi_lat,
                                    pi_lng_g = _dadosSincronismo.monit[i].pi_lng_g,
                                    pi_lng_m = _dadosSincronismo.monit[i].pi_lng_m,
                                    pi_lng_s = _dadosSincronismo.monit[i].pi_lng_s,
                                    pi_lng_d = _dadosSincronismo.monit[i].pi_lng_d,
                                    pi_lng = _dadosSincronismo.monit[i].pi_lng,
                                    last_update = _dadosSincronismo.monit[i].last_update,
                                    ind_sinc = int.Parse(_dadosSincronismo.monit[i].ind_sinc.ToString())
                                };

                                monitRepository.Adicionar(monit);
                            }

                            // Monit_Cod_Arv
                            for (int i = 0; i < _dadosSincronismo.monit_cod_arv.Length; i++)
                            {
                                monit_cod_arv = new Monit_Cod_Arv
                                {
                                    idMonit_Cod_Arv = int.Parse(_dadosSincronismo.monit_cod_arv[i].idMonit_Cod_Arv.ToString()),
                                    monit_cod_arv_id = _dadosSincronismo.monit_cod_arv[i].monit_cod_arv_id,
                                    codigo = _dadosSincronismo.monit_cod_arv[i].codigo,
                                    descr = _dadosSincronismo.monit_cod_arv[i].descr,
                                    last_update = _dadosSincronismo.monit_cod_arv[i].last_update,
                                    ind_sinc = int.Parse(_dadosSincronismo.monit_cod_arv[i].ind_sinc.ToString())
                                };

                                monitCodArvRepository.Adicionar(monit_cod_arv);
                            }

                            // Monit_Parcela
                            for (int i = 0; i < _dadosSincronismo.monit_parcela.Length; i++)
                            {
                                monit_parcela = new Monit_Parcela
                                {
                                    idMonit_Parcela = int.Parse(_dadosSincronismo.monit_parcela[i].idMonit_Parcela.ToString()),
                                    monit_parcela_id = _dadosSincronismo.monit_parcela[i].monit_parcela_id,
                                    parcela = _dadosSincronismo.monit_parcela[i].parcela,
                                    muda_id = _dadosSincronismo.monit_parcela[i].muda_id,
                                    last_update = _dadosSincronismo.monit_parcela[i].last_update,
                                    ind_sinc = int.Parse(_dadosSincronismo.monit_parcela[i].ind_sinc.ToString())
                                };

                                monitParcelaRepository.Adicionar(monit_parcela);
                            }

                            // Colaborador
                            for (int i = 0; i < _dadosSincronismo.colaborador.Length; i++)
                            {
                                colaborador = new Colaborador
                                {
                                    idColaborador = int.Parse(_dadosSincronismo.colaborador[i].idColaborador.ToString()),
                                    colaborador_id = _dadosSincronismo.colaborador[i].colaborador_id,
                                    nome_interno = _dadosSincronismo.colaborador[i].nome_interno,
                                    nome = _dadosSincronismo.colaborador[i].nome,
                                    last_update = _dadosSincronismo.colaborador[i].last_update,
                                    ind_sinc = int.Parse(_dadosSincronismo.colaborador[i].ind_sinc.ToString())
                                };

                                colaboradorRepository.Adicionar(colaborador);
                            }

                            // Lista_Atv
                            for (int i = 0; i < _dadosSincronismo.lista_atv.Length; i++)
                            {
                                lista_atv = new Lista_Atv
                                {
                                    idLista_Atv = int.Parse(_dadosSincronismo.lista_atv[i].idLista_Atv.ToString()),
                                    lista_atv_id = _dadosSincronismo.lista_atv[i].lista_atv_id,
                                    codigo = _dadosSincronismo.lista_atv[i].codigo,
                                    titulo = _dadosSincronismo.objetivo[i].titulo,
                                    drescr = _dadosSincronismo.lista_atv[i].drescr,
                                    media_exec = _dadosSincronismo.lista_atv[i].media_exec,
                                    definicao = _dadosSincronismo.lista_atv[i].definicao,
                                    last_update = _dadosSincronismo.lista_atv[i].last_update,
                                    ind_sinc = int.Parse(_dadosSincronismo.lista_atv[i].ind_sinc.ToString())
                                };

                                listaAtvRepository.Adicionar(lista_atv);
                            }

                            // Qualidade
                            for (int i = 0; i < _dadosSincronismo.qualidade.Length; i++)
                            {
                                qualidade = new Qualidade
                                {
                                    idQualidade = int.Parse(_dadosSincronismo.qualidade[i].idQualidade.ToString()),
                                    qualidade_id = _dadosSincronismo.qualidade[i].qualidade_id,
                                    codigo = _dadosSincronismo.qualidade[i].codigo,
                                    titulo = _dadosSincronismo.qualidade[i].titulo,
                                    last_update = _dadosSincronismo.qualidade[i].last_update,
                                    ind_sinc = int.Parse(_dadosSincronismo.qualidade[i].ind_sinc.ToString())
                                };

                                qualidadeRepository.Adicionar(qualidade);
                            }

                            // Exped_Dest
                            for (int i = 0; i < _dadosSincronismo.exped_dest.Length; i++)
                            {
                                exped_dest = new Exped_Dest
                                {
                                    idExped_Dest = int.Parse(_dadosSincronismo.exped_dest[i].idExped_Dest.ToString()),
                                    exped_dest_id = _dadosSincronismo.exped_dest[i].exped_dest_id,
                                    titulo = _dadosSincronismo.exped_dest[i].titulo,
                                    descr = _dadosSincronismo.exped_dest[i].descr,
                                    last_update = _dadosSincronismo.exped_dest[i].last_update,
                                    ind_sinc = int.Parse(_dadosSincronismo.exped_dest[i].ind_sinc.ToString())
                                };

                                expedDestRepository.Adicionar(exped_dest);
                            }

                            // Estaq
                            for (int i = 0; i < _dadosSincronismo.estaq.Length; i++)
                            {
                                estaq = new Estaq
                                {
                                    idEstaq = int.Parse(_dadosSincronismo.estaq[i].idEstaq.ToString()),
                                    lote_id = _dadosSincronismo.estaq[i].lote_id,
                                    lote = _dadosSincronismo.estaq[i].lote,
                                    muda_id = _dadosSincronismo.estaq[i].muda_id,
                                    muda = _dadosSincronismo.estaq[i].muda,
                                    data_estaq = _dadosSincronismo.estaq[i].data_estaq,
                                    qtde = _dadosSincronismo.estaq[i].qtde,
                                    qualidade_id = _dadosSincronismo.estaq[i].qualidade_id,
                                    qualidade = _dadosSincronismo.estaq[i].qualidade,
                                    colab_estaq_id = _dadosSincronismo.estaq[i].colab_estaq_id,
                                    colab_estaq = _dadosSincronismo.estaq[i].colab_estaq,
                                    last_update = _dadosSincronismo.estaq[i].last_update,
                                    ind_sinc = int.Parse(_dadosSincronismo.estaq[i].ind_sinc.ToString())
                                };

                                estaqRepository.Adicionar(estaq);
                            }

                            #endregion

                            //await _dialogService.AlertAsync("Sincronia", dadosResponse.sinc_msg, "Ok");
                        }
                    }
                    catch (Exception)
                    {
                        await _dialogService.AlertAsync("Erro", dadosResponse.sinc_msg, "Ok");
                    }

                    await RefreshCommandExecute();
                }
            }
            else
            {
                await _dialogService.AlertAsync("Erro", "Sem conexão com a internet!", "Ok");
            }

            IsBusy = false;
        }

        private ArrayList UploadDados()
        {
            #region Listas do Indicadores

            List<Inventario> dadosInventario = new List<Inventario>();
            List<Perda> dadosPerda = new List<Perda>();
            List<Historico> dadosHistorico = new List<Historico>();
            List<Movimentacao> dadosMovimentacao = new List<Movimentacao>();
            List<Monit_Ocorr> dadosOcorrencias = new List<Monit_Ocorr>();
            List<Monit_Med> dadosMedicao = new List<Monit_Med>();
            List<Expedicao> dadosExpedicao = new List<Expedicao>();
            List<Atividade> dadosAtividade = new List<Atividade>();

            #endregion

            ArrayList dadosSincronismo = new ArrayList();

            #region Dados para teste
            //dadosContagem.Add(new Contagem() { idContagem= 01,  disp_id = "01", lote_id = "02", muda_id = "03", qtde = "10", proc = "Deu certo", ponto_controle_id = "01", estagio_id = "01", data_selecao = "01/03/2019", data_inicio = "01/03/2019", data_fim = "03/03/2019", data_estaq = "03/03/2019", colab_estaq_id = "01", colab_sel_id = "6000", qualidade_id = "01", latitude = "010203", longitude = "010203", last_update = "03/03/2019", ind_sinc  = 1});
            //dadosContagem.Add(new Contagem() { disp_id = "01", lote_id = "02", muda_id = "03", qtde = "10", proc = "Deu certo" });
            //dadosContagem.Add(new Contagem() { disp_id = "01", lote_id = "02", muda_id = "03", qtde = "10", proc = "Deu certo" });

            //dadosPerda.Add(new Perda() { disp_id = "01", lote_id = "02", muda_id = "03", qtde = "10", motivo_id = "Tabela Perdas" });
            //dadosPerda.Add(new Perda() { disp_id = "01", lote_id = "02", muda_id = "03", qtde = "10", motivo_id = "Tabela Perdas" });
            //dadosPerda.Add(new Perda() { disp_id = "01", lote_id = "02", muda_id = "03", qtde = "10", motivo_id = "Tabela Perdas" });

            //dadosAtividade.Add(new Atividade() { disp_Id = "01", colaborador_id = "01", lista_atv_id = "01", data_inicio = "01/01/2019", data_fim = "30/01/2019", obs = "Deu certo:D!!!" });
            //dadosAtividade.Add(new Atividade() { disp_Id = "02", colaborador_id = "02", lista_atv_id = "02", data_inicio = "01/02/2019", data_fim = "30/03/2019", obs = "Deu certo:D!!!" });
            //dadosAtividade.Add(new Atividade() { disp_Id = "03", colaborador_id = "03", lista_atv_id = "03", data_inicio = "01/03/2019", data_fim = "30/04/2019", obs = "Deu certo:D!!!" });
            //dadosAtividade.Add(new Atividade() { disp_Id = "04", colaborador_id = "04", lista_atv_id = "04", data_inicio = "01/04/2019", data_fim = "30/05/2019", obs = "Deu certo:D!!!" });
            //dadosAtividade.Add(new Atividade() { disp_Id = "05", colaborador_id = "05", lista_atv_id = "05", data_inicio = "01/06/2019", data_fim = "30/07/2019", obs = "Deu certo:D!!!" });

            //if (dadosContagem.Count() > 0)
            //{
            //    dadosSincronismo.Add(dadosContagem);
            //}

            //if (dadosPerda.Count() > 0)
            //{
            //    dadosSincronismo.Add(dadosPerda);
            //}

            //if (dadosAtividade.Count() > 0)
            //{
            //    dadosSincronismo.Add(dadosAtividade);
            //}
            #endregion

            #region Verifica se existe dados nas tabelas de indicadores
                        
            if (inventarioRepository.ObterTodos().Count() > 0)
            {
                dadosInventario = inventarioRepository.ObterTodos();

                dadosSincronismo.Add(dadosInventario);
            }

            if (perdaRepository.ObterTodos().Count() > 0)
            {
                dadosPerda = perdaRepository.ObterTodos();

                dadosSincronismo.Add(dadosPerda);
            }

            if (historicoRepository.ObterTodos().Count() > 0)
            {
                dadosHistorico = historicoRepository.ObterTodos();

                dadosSincronismo.Add(dadosHistorico);
            }

            if (movimentacaoRepository.ObterTodos().Count() > 0)
            {
                dadosMovimentacao = movimentacaoRepository.ObterTodos();

                dadosSincronismo.Add(dadosMovimentacao);
            }

            if (ocorrenciaRepository.ObterTodos().Count() > 0)
            {
                dadosOcorrencias = ocorrenciaRepository.ObterTodos();

                dadosSincronismo.Add(dadosOcorrencias);
            }

            if (medicaoRepository.ObterTodos().Count() > 0)
            {
                dadosMedicao = medicaoRepository.ObterTodos();

                dadosSincronismo.Add(dadosMedicao);
            }

            if (expedicaoRepository.ObterTodos().Count() > 0)
            {
                dadosExpedicao = expedicaoRepository.ObterTodos();

                dadosSincronismo.Add(dadosExpedicao);
            }

            if (atividadeRepository.ObterTodos().Count() > 0)
            {
                dadosAtividade = atividadeRepository.ObterTodos();

                dadosSincronismo.Add(dadosAtividade);
            }

            #endregion

            return dadosSincronismo;
        }

        private Command _RefreshCommand;
        public Command RefreshCommand => _RefreshCommand ?? (_RefreshCommand = new Command(async () => await RefreshCommandExecute()));

        private async Task RefreshCommandExecute()
        {
            await Task.FromResult<object>(null);

            SincronizarCommand.ChangeCanExecute();

            try
            {
                var dadosUser = userRepository.ObterDados();

                if (dadosUser != null)
                {
                    sincronismo = new Sincronismo
                    {
                        ind_atv = atividadeRepository.ObterTotalDeRegistros(),
                        ind_inv = inventarioRepository.ObterTotalDeRegistros(),
                        ind_per = perdaRepository.ObterTotalDeRegistros(),
                        ind_hist = historicoRepository.ObterTotalDeRegistros(),
                        ind_mov = movimentacaoRepository.ObterTotalDeRegistros(),
                        ind_oco = ocorrenciaRepository.ObterTotalDeRegistros(),
                        ind_mnt = medicaoRepository.ObterTotalDeRegistros(),
                        ind_exp = expedicaoRepository.ObterTotalDeRegistros(),
                        sinc_date = dadosUser.dth_last_sincr
                    };

                    OnPropertyChanged(nameof(IndAtv));
                    OnPropertyChanged(nameof(IndInv));
                    OnPropertyChanged(nameof(IndPer));
                    OnPropertyChanged(nameof(IndHist));
                    OnPropertyChanged(nameof(IndMov));
                    OnPropertyChanged(nameof(IndOco));
                    OnPropertyChanged(nameof(IndMnt));
                    OnPropertyChanged(nameof(IndExp));
                    OnPropertyChanged(nameof(IndIdent));

                    dataSincronizacao = dadosUser.dth_last_sincr.ToString("dd/MM/yyyy HH:mm:ss");
                    OnPropertyChanged(nameof(DhtLastSincr));
                }
                else
                {
                    return;
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}