using Prodfy.Models;
using Prodfy.Services.API;
using Prodfy.Services.Repository;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class SincronismoViewModel : BaseViewModel
    {
        readonly DadosSincronismoService dadosSincronismo = new DadosSincronismoService();
        private Sincronismo sincronismo = null;        
        private User user = null;

        private UserRepository userRepository;
        private AtividadeRepository atividadeRepository;
        private InventarioRepository inventarioRepository;
        private PerdaRepository perdaRepository;
        private HistoricoRepository historicoRepository;
        private EvolucaoRepository evolucaoRepository;
        private OcorrenciaRepository ocorrenciaRepository;
        private MedicaoRepository medicaoRepository;
        private ExpedicaoRepository expedicaoRepository;        

        public SincronismoViewModel()
        {
            userRepository = new UserRepository();
            atividadeRepository =  new AtividadeRepository ();
            inventarioRepository = new InventarioRepository();
            perdaRepository = new PerdaRepository();
            historicoRepository = new HistoricoRepository();
            evolucaoRepository  = new EvolucaoRepository();
            ocorrenciaRepository = new OcorrenciaRepository();
            medicaoRepository = new MedicaoRepository();
            expedicaoRepository = new ExpedicaoRepository();
        }

        //public string DhtLastSincr
        //{
        //    get { return sincronismo.dht_last_sincr = "Não Sincronizado!"; }
        //    set
        //    {
        //        if (sincronismo == null)
        //        {
        //            return;
        //        }
        //        sincronismo.dht_last_sincr = value; OnPropertyChanged();
        //    }
        //}

        public string DhtLastSincr { get => "Não Sincronizado!"; }
        public int? IndAtv { get => sincronismo?.ind_atv; }
        public int? IndInv { get => sincronismo?.ind_inv; }
        public int? IndPer { get => sincronismo?.ind_per; }
        public int? IndHist { get => sincronismo?.ind_hist; }
        public int? IndEvo { get => sincronismo?.ind_evo; }
        public int? IndOco { get => sincronismo?.ind_oco; }
        public int? IndMnt { get => sincronismo?.ind_mnt; }
        public int? IndExp { get => sincronismo?.ind_mnt; }
        public int? IndIdent { get => sincronismo?.ind_mnt; }

        private Command _sincronizarCommand;
        public Command SincronizarCommand =>
            _sincronizarCommand ?? (_sincronizarCommand = new Command(async () => await ExecuteSincronizarCommand()));

        private async Task ExecuteSincronizarCommand()
        {            
            var _dadosSincronismo = await dadosSincronismo.ObterDadosSincronismo(userRepository.ObterDados().app_key, userRepository.ObterDados().lang);            

            user = new User
            {
                ind_ident = _dadosSincronismo.ind_ident,
                ind_inv = _dadosSincronismo.ind_inv,
                ind_per = _dadosSincronismo.ind_per,
                ind_hist = _dadosSincronismo.ind_hist,
                ind_evo = _dadosSincronismo.ind_evo,
                ind_mnt = _dadosSincronismo.ind_mnt,
                ind_exp = _dadosSincronismo.ind_exp,
                ind_atv = _dadosSincronismo.ind_atv,
                uso_liberado = _dadosSincronismo.uso_liberado
            };
            userRepository.Editar(user);            
        }

        private Command _RefreshCommand;
        public Command RefreshCommand => _RefreshCommand ?? (_RefreshCommand = new Command(async () => await RefreshCommandExecute()));

        private async Task RefreshCommandExecute()
        {
            await Task.FromResult<object>(null);

            RefreshCommand.ChangeCanExecute();

            try
            {
                var dadosUser = userRepository.ObterDados();

                if (dadosSincronismo != null)
                {
                    sincronismo = new Sincronismo
                    {
                        ind_atv = atividadeRepository.ObterTotalDeRegistros(),
                        ind_inv = inventarioRepository.ObterTotalDeRegistros(),
                        ind_per = perdaRepository.ObterTotalDeRegistros(),
                        ind_hist = historicoRepository.ObterTotalDeRegistros(),
                        ind_evo = evolucaoRepository.ObterTotalDeRegistros(),
                        ind_oco = ocorrenciaRepository.ObterTotalDeRegistros(),
                        ind_mnt = medicaoRepository.ObterTotalDeRegistros(),
                        ind_exp = expedicaoRepository.ObterTotalDeRegistros(),
                        dht_last_sincr = dadosUser.dht_last_sincr
                    };

                    OnPropertyChanged(nameof(IndAtv));
                    OnPropertyChanged(nameof(IndInv));
                    OnPropertyChanged(nameof(IndPer));
                    OnPropertyChanged(nameof(IndHist));
                    OnPropertyChanged(nameof(IndEvo));
                    OnPropertyChanged(nameof(IndOco));
                    OnPropertyChanged(nameof(IndMnt));
                    OnPropertyChanged(nameof(IndExp));
                    OnPropertyChanged(nameof(IndIdent));
                    OnPropertyChanged(nameof(DhtLastSincr));
                }                            
            }
            catch (Exception)
            {
                return;
            }
        }
        //private User DataUltimaSincrinismo()
        //{
        //    try
        //    {
        //        var dataSincronismo = userRepository.ObterDados();

        //        if (dataSincronismo.dht_last_sincr != null)
        //        {
        //            var sincronismo = new User
        //            {                        
        //                dht_last_sincr = dataSincronismo.dht_last_sincr
        //            };
        //        }

        //        return user;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        //private Sincronismo CarregarDadosSincronismo()
        //{
        //    try
        //    {
        //        var dadosUser = userRepository.ObterDados();

        //        if (dadosSincronismo != null)
        //        {
        //            var sincronismo = new Sincronismo
        //            {
        //                ind_atv = atividadeRepository.ObterTotalDeRegistros(),
        //                ind_inv = inventarioRepository.ObterTotalDeRegistros(),
        //                ind_per = perdaRepository.ObterTotalDeRegistros(),
        //                ind_hist = historicoRepository.ObterTotalDeRegistros(),
        //                ind_evo = evolucaoRepository.ObterTotalDeRegistros(),
        //                ind_oco = ocorrenciaRepository.ObterTotalDeRegistros(),
        //                ind_mnt = medicaoRepository.ObterTotalDeRegistros(),
        //                ind_exp = expedicaoRepository.ObterTotalDeRegistros(),
        //                dht_last_sincr = dadosUser.dht_last_sincr
        //            };
        //        }
        //    }
        //    catch (System.Exception)
        //    {
        //        return;
        //    }
        //}
    }
}