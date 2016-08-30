using Diabhelp.Modules;
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




namespace Diabhelp.Modules.Glucocompteur
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GlucocompteurMainScreen : Page
    {
        int ROW_SIZE = 3;

        private List<StackPanel> nestedPaneList;

        public GlucocompteurMainScreen()
        {
            this.InitializeComponent();
        }

       

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            Debug.WriteLine("GlucocompteurMainScreen::OnNavigatedTo");
        }

        private void alimentsButton_Click(object sender, RoutedEventArgs e)
        {
            mainScreenFrame.Navigate(typeof(GlucocompteurAlimentScreen));
        }

        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            // Not yet implemented
            mainScreenFrame.Navigate(typeof(GlucocompteurMenuScreen));
        }

        void on_Subframe_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("on_Subframe_Loaded");
            Debug.WriteLine("frame : " + mainScreenFrame + " test type : " + typeof(Core.ModulesScreen));
            mainScreenFrame.Navigate(typeof(GlucocompteurAlimentScreen));
        }

        private void diabhelpLbl_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
