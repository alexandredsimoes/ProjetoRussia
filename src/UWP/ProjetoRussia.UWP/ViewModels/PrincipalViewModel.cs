using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using ProjetoRussia.UWP.Models;
using ProjetoRussia.UWP.Services;
using System.Linq;

namespace ProjetoRussia.UWP.ViewModels
{
    public class PrincipalViewModel : ViewModelBase
    {
        private readonly IRussiaServiceApi _russiaServiceApi;

        public PrincipalViewModel(IRussiaServiceApi russiaServiceApi)
        {
            _russiaServiceApi = russiaServiceApi ?? throw new ArgumentNullException(nameof(russiaServiceApi));
        }       

        public async override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            var jogos = await _russiaServiceApi.ListarJogos();
            if (jogos != null)
            {
                UltimosJogos = new ObservableCollection<JogoDto>(jogos?.Where(c => c.Data.Date < DateTime.Today.Date).ToList());
                ProximosJogos = new ObservableCollection<JogoDto>(jogos?.Where(c => c.Data.Date >= DateTime.Today.Date).ToList());
            }
        }

        private ObservableCollection<JogoDto> _UltimosJogos;
        public ObservableCollection<JogoDto> UltimosJogos
        {
            get { return _UltimosJogos; }
            set { SetProperty(ref _UltimosJogos, value); }
        }

        private ObservableCollection<JogoDto> _ProximosJogos;
        public ObservableCollection<JogoDto> ProximosJogos
        {
            get { return _ProximosJogos; }
            set { SetProperty(ref _ProximosJogos, value); }
        }
    }
}
