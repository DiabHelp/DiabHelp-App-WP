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

namespace Diabhelp.Modules.CarnetSuivi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CarnetSuiviEntreesScreen : Page
    {
        public List<Entry> entryListFakeData;
        public CarnetSuiviEntreesScreen()
        {
            this.InitializeComponent();
            entryListFakeData = new List<Entry>();
            entryListFakeData.Add(new Entry("Matin", 112, 180, 2));
            entryListFakeData.Add(new Entry("Midi", 140, 140, 0));
            entryListFakeData.Add(new Entry("En cas", 40, 30, 1));
            entryListFakeData.Add(new Entry("Soir", 112, 180, 2));
            entryList.DataContext = entryListFakeData;
        }

        private void addEntryBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
