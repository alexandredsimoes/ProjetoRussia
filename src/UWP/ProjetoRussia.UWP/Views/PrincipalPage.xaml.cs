using System;

using ProjetoRussia.UWP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ProjetoRussia.UWP.Views
{
    public sealed partial class PrincipalPage : Page
    {
        private PrincipalViewModel ViewModel => DataContext as PrincipalViewModel;

        public PrincipalPage()
        {
            InitializeComponent();
        }
    }
}
