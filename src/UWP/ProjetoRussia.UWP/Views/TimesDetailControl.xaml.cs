using System;

using ProjetoRussia.UWP.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ProjetoRussia.UWP.Views
{
    public sealed partial class TimesDetailControl : UserControl
    {
        public TimeDto MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as TimeDto; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(TimeDto), typeof(TimesDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public TimesDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as TimesDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
