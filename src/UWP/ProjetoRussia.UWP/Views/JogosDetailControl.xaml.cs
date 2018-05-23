using System;

using ProjetoRussia.UWP.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ProjetoRussia.UWP.Views
{
    public sealed partial class JogosDetailControl : UserControl
    {
        public JogoDto MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as JogoDto; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(JogoDto), typeof(JogosDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public JogosDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as JogosDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
