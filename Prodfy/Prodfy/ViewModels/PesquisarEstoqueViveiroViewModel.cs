﻿using Prodfy.Models;
using Prodfy.Services.Dialog;
using Prodfy.Services.Navigation;
using Prodfy.Services.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class PesquisarEstoqueViveiroViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;

        private readonly LoteRepository loteRepositorio;
        private readonly MudaRepository mudaRepositorio;
        private readonly QualidadeRepository qualidadeRepositorio;

        public List<Lote> listaLotes { get; set; }
        public List<Muda> listaMudas { get; set; }
        public List<Qualidade> listaQualidade { get; set; }

        public PesquisarEstoqueViveiroViewModel()
        {
            Title = "Estoque Viveiro";

            navigationService = new NavigationService();
            dialogService = new DialogService();

            loteRepositorio = new LoteRepository();
            mudaRepositorio = new MudaRepository();
            qualidadeRepositorio = new QualidadeRepository();

            Lotes();
            Mudas();
            Qualidades();
        }        

        private bool _visible;
        public bool Visible
        {
            get => _visible;
            set => SetProperty(ref _visible, value);
        }

        private bool _visibleMuda = true;
        public bool VisibleMuda
        {
            get => _visibleMuda;
            set => SetProperty(ref _visibleMuda, value);
        }

        private bool _visibleQualidade = true;
        public bool VisibleQualidade
        {
            get => _visibleQualidade;
            set => SetProperty(ref _visibleQualidade, value);
        }

        private Lote _loteSelecionado;
        public Lote LoteSelecionado
        {
            get => _loteSelecionado;
            set
            {
                SetProperty(ref _loteSelecionado, value);

                if (_loteSelecionado != null)
                {
                    _listaMudas = Mudas();
                    VisibleMuda = false;
                }
            }
        }

        private List<Lote> _listaDeLotes;
        public List<Lote> ListaDeLotes
        {
            get => _listaDeLotes;
            set => SetProperty(ref _listaDeLotes, value);
        }

        private Muda _mudaSelecionada;
        public Muda MudaSelecionada
        {
            get => _mudaSelecionada;
            set
            {
                SetProperty(ref _mudaSelecionada, value);

                if (_mudaSelecionada != null)
                {
                    _listaQualidades = Qualidades();
                    VisibleQualidade = false;
                }
            }
        }

        private List<Muda> _listaMudas;
        public List<Muda> ListaMudas
        {
            get => _listaMudas;
            set => SetProperty(ref _listaMudas, value);
        }

        private Qualidade _qualidadeSelecionada;
        public Qualidade QualidadeSelecionada
        {
            get => _qualidadeSelecionada;
            set => SetProperty(ref _qualidadeSelecionada, value);
        }

        private List<Qualidade> _listaQualidades;
        public List<Qualidade> ListaQualidades
        {
            get => _listaQualidades;
            set => SetProperty(ref _listaQualidades, value);
        }

        private Command _titleViewBotaoVoltarCommand;
        public Command TitleViewBotaoVoltarCommand =>
            _titleViewBotaoVoltarCommand ?? (_titleViewBotaoVoltarCommand = new Command(async () => await ExecuteTitleViewBotaoVoltarCommand()));

        private async Task ExecuteTitleViewBotaoVoltarCommand() => await navigationService.PopAsync();        

        private Command _pesquisaEstoqueViveiroCommand;
        public Command PesquisaEstoqueViveiroCommand =>
            _pesquisaEstoqueViveiroCommand ?? (_pesquisaEstoqueViveiroCommand = new Command(() => ExecutePesquisaEstoqueViveiroCommand()));

        private void ExecutePesquisaEstoqueViveiroCommand() => Visible = true;

        private Command _tappedMudaCommand;
        public Command TappedMudaCommand =>
            _tappedMudaCommand ?? (_tappedMudaCommand = new Command(async () => await VerificaPickerMudas()));

        // Verifica se os dados do picker e nulo e não envia a mensagem.
        private async Task VerificaPickerMudas()
        {
            if (_listaMudas == null)
                await dialogService.AlertAsync("ALERTA", "Selecione um LOTE para gerar a lista de MUDAS!", "Ok");
        }

        private Command _tappedQualidadeCommand;
        public Command TappedQualidadeCommand =>
            _tappedQualidadeCommand ?? (_tappedQualidadeCommand = new Command(async () => await VerificaPickerQualidades()));

        // Verifica se os dados do picker e nulo e não envia a mensagem.
        private async Task VerificaPickerQualidades()
        {
            if (_listaQualidades == null)
                await dialogService.AlertAsync("ALERTA", "Selecione um MUDA para gerar a lista de QUALIDADES!", "Ok");
        }

        private List<Lote> Lotes()
        {
            return listaLotes = loteRepositorio.ObterTodos();
        }

        private List<Muda> Mudas()
        {
            return listaMudas = mudaRepositorio.ObterTodos();
        }

        private List<Qualidade> Qualidades()
        {
            return listaQualidade = qualidadeRepositorio.ObterTodos();
        }
    }
}