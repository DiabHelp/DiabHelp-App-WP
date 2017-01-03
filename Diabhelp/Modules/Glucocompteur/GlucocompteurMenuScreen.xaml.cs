using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class GlucocompteurMenuScreen : Page
    {
        GlucocompteurMainScreen parent;
        public ObservableCollection<Menu> menuList = new ObservableCollection<Menu>();
        public GlucocompteurMenuScreen()
        {
            this.InitializeComponent();
        }

   protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            Debug.WriteLine("ModuleScreen::OnNavigatedTo");
            parent = e.Parameter as GlucocompteurMainScreen;
            if (parent.getMenuList().Any())
            {
                menuList = new ObservableCollection<Menu>(parent.getMenuList());
            }
            menuMainContainer.ItemsSource = menuList;
        }

        private void deleteMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            Menu toRemove = ((Button)sender).DataContext as Menu;
            parent.removeFromMenu(toRemove);
            menuList.Remove(toRemove);
            Debug.WriteLine(menuMainContainer.ItemsSource.GetType().Name);
        }
    }
}
