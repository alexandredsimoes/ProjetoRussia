using System;

using ProjetoRussia.UWP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ProjetoRussia.UWP.Views
{
    public sealed partial class TimeCriarPage : Page
    {
        private TimeCriarViewModel ViewModel => DataContext as TimeCriarViewModel;

        public TimeCriarPage()
        {
            InitializeComponent();
        }
    }
}
