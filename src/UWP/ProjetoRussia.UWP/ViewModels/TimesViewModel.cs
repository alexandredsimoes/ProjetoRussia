using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows.Input;

using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

using ProjetoRussia.UWP.Models;
using ProjetoRussia.UWP.Services;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace ProjetoRussia.UWP.ViewModels
{
    public class TimesViewModel : ViewModelBase
    {                
        private readonly INavigationService _navigationService;
        private readonly IRussiaServiceApi _russiaServiceApi;

        public TimesViewModel(INavigationService navigationServiceInstance,
           IRussiaServiceApi russiaServiceApi)
        {
            _russiaServiceApi = russiaServiceApi;
            _navigationService = navigationServiceInstance;
        }

        private TimeDto _selected;

        public TimeDto Selected
        {
            get => _selected;
            set => SetProperty(ref _selected, value);
        }

        public ObservableCollection<TimeDto> Times { get; } = new ObservableCollection<TimeDto>();

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            await LoadDataAsync();
        }

        public async Task LoadDataAsync()
        {
            var data = await _russiaServiceApi.ListarTimes();
            if(data?.Count() > 0)
            {
                Times.Clear();

                foreach (var item in data)
                {
                    Times.Add(item);
                }

                Selected = Times.First();
            }

        }
        public string Teste()
        {
            return "";
        }
        public async Task<ImageSource> ConverteImagem(byte[] bandeira)
        {
            return await ImageFromBytes(bandeira);
        }
        public async Task<BitmapImage> ImageFromBytes(byte[] bytes)
        {
            BitmapImage image = new BitmapImage();
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                await stream.WriteAsync(bytes.AsBuffer());
                stream.Seek(0);
                await image.SetSourceAsync(stream);
            }
            return image;
        }

        private DelegateCommand _criarTimeCommand;
        public DelegateCommand CriarTimeCommand =>
            _criarTimeCommand ?? (_criarTimeCommand = new DelegateCommand(ExecuteCriarTimeCommand));

        void ExecuteCriarTimeCommand()
        {
            _navigationService.Navigate(PageTokens.TimeCriarPage, null);
        }

    }
}
