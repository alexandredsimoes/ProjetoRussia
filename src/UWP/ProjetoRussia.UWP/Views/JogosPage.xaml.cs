using System;

using ProjetoRussia.UWP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ProjetoRussia.UWP.Views
{
    public sealed partial class JogosPage : Page
    {
        private JogosViewModel ViewModel => DataContext as JogosViewModel;

        public JogosPage()
        {
            InitializeComponent();
        }
    }
}
