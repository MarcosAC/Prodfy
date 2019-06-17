using Prodfy.Models;
using Prodfy.Services;
using Prodfy.Services.Dialog;
using Prodfy.Services.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    class CadastroHistoricoViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;

        private readonly LoteRepository loteRepositorio;
        private readonly HistoricoRepository historicoRepositorio;

        public CadastroHistoricoViewModel()
        {
            Title = "Histórico";

            navigationService = new NavigationService();
            dialogService = new DialogService();

            loteRepositorio = new LoteRepository();
            historicoRepositorio = new HistoricoRepository();

            loteRepositorio.ListaLotes();

            Lotes();
        }

        public List<Lote> listaLotes { get; set; }

        private int contadorTitulo = 180;
        private string _contagemCaracteresTitulo;
        public string ContagemCaracteresTitulo { get => _contagemCaracteresTitulo = $"Título: {contadorTitulo}"; }

        private int contatorTexto = 2000;
        private string _contagemCaracteresTexto;
        public string ContagemCaracteresTexto { get => _contagemCaracteresTexto = $"Texto: {contatorTexto}"; }

        private string _dispId;
        public string DispId
        {
            get => _dispId;
            set => SetProperty(ref _dispId, value);
        }

        private Lote _loteSelecionado;
        public Lote LoteSelecionado
        {
            get => _loteSelecionado;
            set => SetProperty(ref _loteSelecionado, value);
        }

        private string _lote;
        private string Lote
        {
            get => _lote;
            set => SetProperty(ref _lote, value);
        }

        private DateTime _data;
        public DateTime Data
        {
            get => _data = DateTime.Today;
            set => SetProperty(ref _data, value);
        }

        private string _titulo;
        public string Titulo
        {
            get => _titulo;
            set
            {
                SetProperty(ref _titulo, value);

                //foreach (char item in _titulo)
                //{
                //    var contadorAtual = _titulo.Length;

                //    var contadorAntigo = contadorAtual;

                //    if (contadorAtual == _titulo.Length - 1)
                //    {
                //        contadorTitulo += 1;
                //    }
                //    contadorTitulo -= 1;
                //    OnPropertyChanged(nameof(ContagemCaracterTitulo));
                //}

                //if (contadorTitulo >= contadorTitulo)
                //{
                //    contadorTitulo -= 1;
                //    OnPropertyChanged(nameof(ContagemCaracterTitulo));
                //}            
            }
        }

        private string _texto;
        public string Texto
        {
            get => _texto;
            set => SetProperty(ref _texto, value);
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

        private Task ExecuteCancelarCadastroCommand()
        {
            throw new NotImplementedException();
        }

        private Command _salvarCadastroCommand;
        public Command SalvarCadastroCommand =>
            _salvarCadastroCommand ?? (_salvarCadastroCommand = new Command(async () => await ExecuteSalvarCadastroCommand()));

        private async Task ExecuteSalvarCadastroCommand()
        {
            try
            {
                var historico = new Historico
                {
                    lote_id = LoteSelecionado.lote_id,
                    data = Data,
                    titulo = Titulo,
                    texto = Texto
                };

                bool historicoAceite = await dialogService.AlertAsync("HISTÓRICO", "Deseja salvar os dados informados?", "Sim", "Não");

                if (historicoAceite)
                {
                    try
                    {
                        historicoRepositorio.Adicionar(historico);
                        await dialogService.AlertAsync("HISTÓRICO", "Dados salvos com sucesso!", "Ok");
                    }
                    catch (Exception)
                    {
                        await dialogService.AlertAsync("HISTÓRICO", "Erro ao salvar dados!", "Ok");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private List<Lote> Lotes()
        {
            return listaLotes = loteRepositorio.ObterTodos();
        }
    }
}
