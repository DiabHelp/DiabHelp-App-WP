using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Diabhelp.Modules.Glucocompteur
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GlucocompteurAlimentScreen : Page
    {
        List<String> fakeDB = new List<string>() { "Alim1", "Alim2", "Alim3", "Alim4", "Alim5", "Alim6" };
        SQLiteConnection db;
        public String fieldObjectName = "alimentname";
        public String fieldObjectGlucides = "Glucides";
        public String tableName = "aliments_search";
        public List<Aliment> alimlist = new List<Aliment>();

        public Aliment selectedAliment { get; private set; }

        private async void loadAlimentsDB()
        {
            string DBFile = @"Assets\aliments.db";
            StorageFolder InstallationFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFile file = await InstallationFolder.GetFileAsync(DBFile);
            db = new SQLiteConnection(file.Path);

        }

        public GlucocompteurAlimentScreen()
        {
            this.InitializeComponent();
            Debug.WriteLine("Open file blabla");
            string DBPath = @"Assets\aliments.db";
            FileStream fs = File.OpenRead(DBPath);
            if (fs == null)
            {
                Debug.WriteLine("Rate openfile");
                return;
            }
            loadAlimentsDB();
            alimentInput.ItemsSource = alimlist;
        }

        private void addAlimentBtn_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Adding aliment : " + alimentInput.Text);
        }

        private List<Aliment> getAlimListFromDB(String input)
        {
            Debug.WriteLine("Try getAlimList for input: " + input);

            string sql = "";
            input= input.Replace("'", "''").Replace("\"", "\"\"");
            sql += "SELECT alimentname, Glucides FROM " + tableName;
            sql += " WHERE " + fieldObjectName + " LIKE '%" + input + "%'";
            sql += " ORDER BY " + fieldObjectName + "='" + input + "' DESC,";
            sql += fieldObjectName + " LIKE '" + input + "%' DESC,";
            sql += fieldObjectName + " LIKE '%" + input + "%' DESC";
            sql += " LIMIT 8";

            List<Aliment> newalimlist = db.Query<Aliment>(sql);
            foreach (Aliment alim in newalimlist)
            {
                Debug.WriteLine("Name : " + alim.alimentname + ", glucides : " + alim.Glucides);
            }
            return newalimlist;
        }

        private void alimentInput_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                //sender.ItemsSource = fakeDB.Where(s => s.Contains(sender.Text));
                alimlist = getAlimListFromDB(sender.Text);
                sender.ItemsSource = alimlist;
            }

        }

        private void alimentInput_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            selectedAliment = (Aliment)args.SelectedItem;
            sender.Text = selectedAliment.alimentname;
            Debug.WriteLine("Selected aliment : " + selectedAliment.alimentname + " glucides = " + selectedAliment.Glucides);
        }
    }
}
