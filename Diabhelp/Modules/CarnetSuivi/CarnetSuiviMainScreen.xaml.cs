using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Diabhelp.Modules.CarnetSuivi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CarnetSuiviMainScreen : Page
    {
        public CarnetSuiviMainScreen()
        {
            this.InitializeComponent();
        }

        private void entreesButton_Click(object sender, RoutedEventArgs e)
        {
            mainScreenFrame.Navigate(typeof(CarnetSuiviEntreesScreen), this);
        }

        private void statistiquesButton_Click(object sender, RoutedEventArgs e)
        {
            mainScreenFrame.Navigate(typeof(CarnetSuiviStatistiquesScreen), this);
        }

        void on_Subframe_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("on_Subframe_Loaded");
            Debug.WriteLine("frame : " + mainScreenFrame + " test type : " + typeof(Core.ModulesScreen));
            mainScreenFrame.Navigate(typeof(CarnetSuiviEntreesScreen), this);
        }
    }
}
