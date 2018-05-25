using System;

using ProjetoRussia.UWP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ProjetoRussia.UWP.Views
{
    public sealed partial class JogosCriarPage : Page
    {
        private JogosCriarViewModel ViewModel => DataContext as JogosCriarViewModel;

        public JogosCriarPage()
        {
            InitializeComponent();
        }
    }
}
