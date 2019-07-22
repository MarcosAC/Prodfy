using Prodfy.Models;
using Prodfy.Services.Dialog;
using Prodfy.Services.Navigation;
using Prodfy.Services.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class CadastroAtividadeViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;

        private readonly ColaboradorRepository colaboradorRepositorio;
        private readonly ListaAtvRepository listaAtvRepositorio;
        private readonly AtividadeRepository atividadeRepositorio;

        public CadastroAtividadeViewModel()
        {
            Title = "Atividades";

            navigationService = new NavigationService();
            dialogService = new DialogService();

            colaboradorRepositorio = new ColaboradorRepository();
            listaAtvRepositorio = new ListaAtvRepository();
            atividadeRepositorio = new AtividadeRepository();

            Colaboradores();
            ListaAtividades();
        }

        public List<Colaborador> listaColaboradores { get; set; }
        public List<Lista_Atv> listaAtividades { get; set; }

        private string _dispId;
        public string DispId
        {
            get => _dispId;
            set => SetProperty(ref _dispId, value);
        }

        private string _colaboradorId;
        public string ColaboradorId
        {
            get => _colaboradorId;
            set => SetProperty(ref _colaboradorId, value);
        }

        private Colaborador _colaboradorSelecionado;
        public Colaborador ColaboradorSelecionado
        {
            get => _colaboradorSelecionado;
            set => SetProperty(ref _colaboradorSelecionado, value);
        }

        private string _listaAtvId;
        public string ListaAtvId
        {
            get => _listaAtvId;
            set => SetProperty(ref _listaAtvId, value);
        }

        private Lista_Atv _listaAtividadeSelecionada;
        public Lista_Atv ListaAtividadeSelecionada
        {
            get => _listaAtividadeSelecionada;
            set => SetProperty(ref _listaAtividadeSelecionada, value);
        }

        private DateTime _dataInicio = DateTime.Today;
        public DateTime DataInicio
        {
            get => _dataInicio;
            set => SetProperty(ref _dataInicio, value);
        }

        private DateTime _dataFim = DateTime.Today;
        public DateTime DataFim
        {
            get => _dataFim;
            set => SetProperty(ref _dataFim, value);
        }

        private TimeSpan _horaInicio;
        public TimeSpan HoraInicio
        {
            get => _horaInicio;
            set => SetProperty(ref _horaInicio, value);
        }

        private TimeSpan _horaConclusao;
        public TimeSpan HoraConclusao
        {
            get => _horaConclusao;
            set => SetProperty(ref _horaConclusao, value);
        }

        private string _obs;
        public string Obs
        {
            get => _obs;
            set => SetProperty(ref _obs, value);
        }

        private string _lastUpdate;
        public string LastUpdate
        {
            get => _lastUpdate;
            set => SetProperty(ref _lastUpdate, value);
        }

        private string _indSinc;
        public string IndSinc
        {
            get => _indSinc;
            set => SetProperty(ref _indSinc, value);
        }

        private Command _titleViewBotaoVoltarCommand;
        public Command TitleViewBotaoVoltarCommand =>
            _titleViewBotaoVoltarCommand ?? (_titleViewBotaoVoltarCommand = new Command(async () => await ExecuteTitleViewBotaoVoltarCommand()));

        private async Task ExecuteTitleViewBotaoVoltarCommand() => await navigationService.PopAsync();

        private Command _cancelarCadastroCommand;
        public Command CancelarCadastroCommand =>
            _cancelarCadastroCommand ?? (_cancelarCadastroCommand = new Command(async () => await ExecuteCancelarCadastroCommand()));

        private async Task ExecuteCancelarCadastroCommand() => await navigationService.PopAsync();

        private Command _salvarCadastroCommand;
        public Command SalvarCadastroCommand =>
            _salvarCadastroCommand ?? (_salvarCadastroCommand = new Command(async () => await ExecuteSalvarCadastroCommandAsync()));

        private async Task ExecuteSalvarCadastroCommandAsync()
        {            
            try
            {
                await ValidarCampos();

                var atividade = new Atividade
                {
                    colaborador_id = ColaboradorSelecionado.colaborador_id,
                    lista_atv_id = ListaAtividadeSelecionada.lista_atv_id,
                    data_inicio = DataInicio + HoraInicio,
                    data_fim = DataFim + HoraConclusao,
                    obs = Obs
                };

                if (DataInicio != null && DataFim != null)
                {
                    if (DataFim <= DataInicio)
                    {
                        await dialogService.AlertAsync("ALERTA", "DATA FIM deve ser superior à DATA INÍCIO!", "Ok");
                        return;
                    }

                    bool atividadeAceite = await dialogService.AlertAsync("ATIVIDADES", "Deseja salvar os dados informados?", "Sim", "Não");

                    if (atividadeAceite)
                    {
                        try
                        {
                            atividadeRepositorio.Adicionar(atividade);
                            await dialogService.AlertAsync("ATIVIDADES", "Dados salvos com sucesso!", "Ok");
                            await navigationService.PopAsync();
                        }
                        catch (Exception)
                        {
                            await dialogService.AlertAsync("ATIVIDADES", "Erro ao salvar dados!", "Ok");
                        }
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private List<Colaborador> Colaboradores()
        {
            return listaColaboradores = colaboradorRepositorio.ObterTodos();
        }

        private List<Lista_Atv> ListaAtividades()
        {
            return listaAtividades = listaAtvRepositorio.ObterTodos();
        }

        private async Task ValidarCampos()
        {
            if (ColaboradorSelecionado == null)
            {
                await dialogService.AlertAsync("ALERTA", "O campo COLABORADOR é obrigatório!", "Ok");
                return;
            }

            if (ListaAtividadeSelecionada == null)
            {
                await dialogService.AlertAsync("ALERTA", "O campo ATIVIDADE é obrigatório!", "Ok");
                return;
            }

            if (DataInicio == null)
            {
                await dialogService.AlertAsync("ALERTA", "O campo DATA INÍCIO é obrigatório!", "Ok");
                return;
            }

            if (DataFim == null)
            {
                await dialogService.AlertAsync("ALERTA", "O campo DATA FIM é obrigatório!", "Ok");
                return;
            }                       

            if (HoraInicio == null)
            {
                await dialogService.AlertAsync("ALERTA", "O campo HORA INÍCIO é obrigatório!", "Ok");
                return;
            }

            if (HoraConclusao == null)
            {
                await dialogService.AlertAsync("ALERTA", "O campo HORA CONCLUSÃO é obrigatório!", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(Obs))
            {
                await dialogService.AlertAsync("ALERTA", "O campo OBSERVAÇÃO é obrigatório!", "Ok");
                return;
            }
        }
    }
}