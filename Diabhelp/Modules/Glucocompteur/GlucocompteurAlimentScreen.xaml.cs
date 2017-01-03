using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Diabhelp.Modules.Glucocompteur
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GlucocompteurAlimentScreen : Page
    {
        SQLiteConnection db = null;
        public ObservableCollection<Aliment> currentMenu = new ObservableCollection<Aliment>();
        private GlucocompteurAddAliment alimentDialog;
        private GlucocompteurMainScreen parent;

        public GlucocompteurAlimentScreen()
        {
            this.InitializeComponent();

            alimentDialog = new GlucocompteurAddAliment();
            alimentList.DataContext = currentMenu;
        }

        private async void addAlimentBtn_Click(object sender, RoutedEventArgs e)
        {
            ContentDialogResult result = await alimentDialog.ShowAsync();
            Aliment selected;
            if (result == ContentDialogResult.Primary)
            {
                selected = alimentDialog.selectedAliment;
                Debug.WriteLine("Selected aliment : " + selected.alimentname + " glucides = " + selected.Glucides + " qty = " + selected.weight);
                currentMenu.Add(selected);
            }
            else
                Debug.WriteLine("Cancel addAliment");
        }

        private void eraseMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            currentMenu.Clear();
        }

        private async void addMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            GlucocompteurSaveMenu menuSave = new GlucocompteurSaveMenu();

            ContentDialogResult result = await menuSave.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                Menu toAdd = new Menu(menuSave.menuName, currentMenu);
                parent.addToMenus(toAdd);
                currentMenu = new ObservableCollection<Aliment>();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            Debug.WriteLine("ModuleScreen::OnNavigatedTo");
            parent = e.Parameter as GlucocompteurMainScreen;
            if (this.db == null)
            {
                this.db = parent.getAlimentDB();
                alimentDialog.setDBContent(db);
            }
        }
    }
}
