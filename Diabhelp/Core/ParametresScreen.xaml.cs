using System;
using System.Collections.Generic;
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

namespace Diabhelp.Core
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ParametresScreen : Page
    {
        public ParametresScreen()
        {
            this.InitializeComponent();
        }

        private void profileButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ProfilScreen));
        }

        private void faqButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void manuelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void siteButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.System.Launcher.LaunchUriAsync(new Uri("http://diabhelp.org/"));
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void facebookButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.System.Launcher.LaunchUriAsync(new Uri("https://www.facebook.com/diabhelp"));
        }
    }
}
