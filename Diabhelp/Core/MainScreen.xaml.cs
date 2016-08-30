using Diabhelp.Core;
using Diabhelp.Core.Api.ResponseModels;
using System;
using System.Collections;
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

namespace Diabhelp
{
    /// <summary>
    /// Module Screen page
    /// </summary>

    public sealed partial class MainScreen : Page
    {
        private Frame rootFrame;
        LoginResponseBody loginInfo;

        public MainScreen()
        {
            this.InitializeComponent();
            rootFrame = (Frame)Window.Current.Content;
        }

        void on_Subframe_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("on_Subframe_Loaded");
            Debug.WriteLine("frame : " + mainScreenFrame + " test type : " + typeof(Core.ModulesScreen));
            mainScreenFrame.Navigate(typeof(Core.ModulesScreen), ModuleLoader.Instance);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Debug.WriteLine("MainScreen::OnNavigatedTo");
            loginInfo = e.Parameter as LoginResponseBody;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        //TODO : check si on y est déjà
        private void accueilButton_Click(object sender, RoutedEventArgs e)
        {
            mainScreenFrame.Navigate(typeof(Core.ModulesScreen), ModuleLoader.Instance);
        }

        //TODO : check si on y est déjà
        private void catalogueButton_Click(object sender, RoutedEventArgs e)
        {
            mainScreenFrame.Navigate(typeof(Core.CatalogueScreen));
        }


        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            mainScreenFrame.Navigate(typeof(Core.ParametresScreen), loginInfo);
        }
    }
}
