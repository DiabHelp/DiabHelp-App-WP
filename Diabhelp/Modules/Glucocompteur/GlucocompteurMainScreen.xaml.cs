using Diabhelp.Modules;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    /// 
    public sealed partial class GlucocompteurMainScreen : Page
    {

        private List<Menu> menuList;
        SQLiteConnection db;
        Windows.Storage.ApplicationDataContainer localSettings;

        public GlucocompteurMainScreen()
        {
            this.InitializeComponent();
            Debug.WriteLine("Trying File.OpenRead()");
            string DBPath = @"Assets\aliments.db";
            FileStream fs = File.OpenRead(DBPath);
            if (fs != null)
                loadAlimentsDB();
            getSavedMenuList();

        }

        private async void loadAlimentsDB()
        {
            string DBFile = @"Assets\aliments.db";
            StorageFolder InstallationFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFile file = await InstallationFolder.GetFileAsync(DBFile);
            Debug.WriteLine("Beging new SQLiteConnection())");
            db = new SQLiteConnection(file.Path);
            Debug.WriteLine("End new SQLiteConnection())");
        }

        private void getSavedMenuList()
        {
            localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            if (localSettings.Values["GlucocompteurMenuList"] == null)
            {
                Debug.WriteLine("GlucocompteurMenuList Settings null");
                menuList = new List<Menu>();
            }
            else
            {
                string raw = localSettings.Values["GlucocompteurMenuList"] as string;
                Debug.WriteLine(raw);
                menuList = JsonConvert.DeserializeObject<List<Menu>>(raw);

            }
        }

        private void saveMenuList()
        {
            if (menuList.Count > 0)
                localSettings.Values["GlucocompteurMenuList"] = JsonConvert.SerializeObject(menuList);
            else
                localSettings.Values["GlucocompteurMenuList"] = null;
        }

       public void addToMenus(Menu toAdd)
        {
            menuList.Add(toAdd);
            saveMenuList();
        }

        public void removeFromMenu(Menu toRemove)
        {
            menuList.Remove(toRemove);
            saveMenuList();
        }

        public SQLiteConnection getAlimentDB()
        {
            return db;
        }

        public List<Menu> getMenuList()
        {
            return menuList;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            Debug.WriteLine("GlucocompteurMainScreen::OnNavigatedTo");
        }

        private void alimentsButton_Click(object sender, RoutedEventArgs e)
        {
            mainScreenFrame.Navigate(typeof(GlucocompteurAlimentScreen), this);
        }

        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            mainScreenFrame.Navigate(typeof(GlucocompteurMenuScreen), this);
        }

        void on_Subframe_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("on_Subframe_Loaded");
            Debug.WriteLine("frame : " + mainScreenFrame + " test type : " + typeof(Core.ModulesScreen));
            mainScreenFrame.Navigate(typeof(GlucocompteurAlimentScreen), this);
        }
    }
}
