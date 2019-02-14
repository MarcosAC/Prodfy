using Prodfy.Models;
using Prodfy.Services.API;
using Prodfy.Services.Repository;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class SincronismoViewModel : BaseViewModel
    {
        readonly DadosSincronismoService dadosSincronismo = new DadosSincronismoService();
        private readonly Sincronismo _sincronismo = null;        
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

            _sincronismo = CarregarDadosSincronismo();
        }

        public string DhtLastSincr
        {
            get { return _sincronismo.dht_last_sincr = "Não Sincronizado!"; }
            set
            {
                if (_sincronismo == null)
                {
                    return;
                }
                _sincronismo.dht_last_sincr = value; OnPropertyChanged();
            }
        }

        public int? IndAtv
        {
            get { return _sincronismo?.ind_atv; }
            set { _sincronismo.ind_atv = value; OnPropertyChanged(); }
        }
        
        public int? IndInv
        {
            get { return _sincronismo?.ind_inv; }
            set { _sincronismo.ind_inv = value; OnPropertyChanged(); }
        }

        public int? IndPer
        {
            get { return _sincronismo?.ind_per; }
            set { _sincronismo.ind_per = value; OnPropertyChanged(); }
        }
       
        public int? IndHist
        {            
            get { return _sincronismo?.ind_hist; }
            set { _sincronismo.ind_hist = value; OnPropertyChanged(); }
        }
       
        public int? IndEvo
        {
            get { return _sincronismo?.ind_evo; }
            set { _sincronismo.ind_evo = value; OnPropertyChanged(); }
        }
        
        public int? IndOco
        {
            get { return _sincronismo?.ind_oco; }
            set { _sincronismo.ind_oco = value; OnPropertyChanged(); }
        }

        public int? IndMnt
        {
            get { return _sincronismo?.ind_mnt; }
            set { _sincronismo.ind_mnt = value; OnPropertyChanged(); }
        }
        
        public int? IndExp
        {
            get { return _sincronismo?.ind_mnt; }
            set { _sincronismo.ind_mnt = value; OnPropertyChanged(); }
        }
        
        public int? IndIdent
        {
            get { return _sincronismo?.ind_mnt; }
            set { _sincronismo.ind_mnt = value; OnPropertyChanged(); }
        }       

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

        private Sincronismo CarregarDadosSincronismo()
        {
            var dadosUser = userRepository.ObterDados();

            if (dadosSincronismo != null)
            {
                var sincronismo = new Sincronismo
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
                return sincronismo;
            }
            return null;
        }
    }
}