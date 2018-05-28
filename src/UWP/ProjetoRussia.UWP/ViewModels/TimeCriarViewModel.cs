using System;
using System.Collections.Generic;
using System.IO;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using ProjetoRussia.UWP.Models;
using ProjetoRussia.UWP.Services;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace ProjetoRussia.UWP.ViewModels
{
    public class TimeCriarViewModel : ViewModelBase
    {
        private readonly IRussiaServiceApi _russiaServiceApi;
        private readonly INavigationService _navigationService;

        public TimeCriarViewModel(IRussiaServiceApi russiaServiceApi, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _russiaServiceApi = russiaServiceApi ?? throw new ArgumentNullException(nameof(russiaServiceApi));
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            if (e.Parameter == null)
            {
                Time = new TimeDto();
            }
        }

        private DelegateCommand _selecionarImagemCommand;
        public DelegateCommand SelecionarImagemCommand =>
            _selecionarImagemCommand ?? (_selecionarImagemCommand = new DelegateCommand(ExecuteSelecionarImagemCommand));

        async void ExecuteSelecionarImagemCommand()
        {
            var picker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.PicturesLibrary
            };

            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".png");

            StorageFile file = await picker.PickSingleFileAsync();

            if (file != null)
            {
                var buffer = await FileIO.ReadBufferAsync(file);

                using (DataReader reader = DataReader.FromBuffer(buffer))
                {
                    var imageBytes = new byte[buffer.Length];

                    reader.ReadBytes(imageBytes);

                    Time.Bandeira = imageBytes;
                }
            }
            else
            {
                // return null;
            }
        }

        private DelegateCommand _SalvarCommand;
        public DelegateCommand SalvarCommand =>
            _SalvarCommand ?? (_SalvarCommand = new DelegateCommand(ExecuteSalvarCommand));

        async void ExecuteSalvarCommand()
        {
            if (await _russiaServiceApi.CriarTime(Time))
            {
                if (_navigationService.CanGoBack())
                    _navigationService.GoBack();
            }
        }

        private TimeDto _Time;
        public TimeDto Time
        {
            get { return _Time; }
            set { SetProperty(ref _Time, value); }
        }

        public object ObterImagem()
        {
            return Time?.Bandeira;
        }

        private string _NomeJogador;
        public string NomeJogador
        {
            get { return _NomeJogador; }
            set { SetProperty(ref _NomeJogador, value); }
        }

        private int _NumeroCamisa;
        public int NumeroCamisa
        {
            get { return _NumeroCamisa; }
            set { SetProperty(ref _NumeroCamisa, value); }
        }

        private string _PosicaoJogador;
        public string PosicaoJogador
        {
            get { return _PosicaoJogador; }
            set { SetProperty(ref _PosicaoJogador, value); }
        }

        private DelegateCommand _AdicionarJogadorCommand;
        public DelegateCommand AdicionarJogadorCommand =>
            _AdicionarJogadorCommand ?? (_AdicionarJogadorCommand = new DelegateCommand(ExecuteAdicionarJogadorCommand));

        void ExecuteAdicionarJogadorCommand()
        {
            Action<string> mensagem = async (s) =>
            {
                MessageDialog dlg = new MessageDialog(s);
                await dlg.ShowAsync();
            };
            if (String.IsNullOrWhiteSpace(NomeJogador))
            {
                mensagem("Informe o nome do jogador.");
                return;
            }

            if (String.IsNullOrWhiteSpace(PosicaoJogador))
            {
                mensagem("Informe a posição do jogador.");
                return;
            }
            if (NumeroCamisa <=0)
            {
                mensagem("Informe o número da camisa.");
                return;
            }
            Time?.Jogadores.Add(new JogadorDto()
            {
                Nome = NomeJogador,
                Ficha = new FichaDto()
                {
                    Altura = 1.90M,
                    Naturalidade = "Sem",
                    Posicao = PosicaoJogador,
                    Camisa = NumeroCamisa
                }
            });

            NomeJogador = string.Empty;
            PosicaoJogador = string.Empty;
            NumeroCamisa = 0;

            RaisePropertyChanged("Time");
            RaisePropertyChanged("Time.Jogadores");
        }
    }
}
