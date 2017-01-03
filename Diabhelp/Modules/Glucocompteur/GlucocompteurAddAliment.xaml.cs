using SQLite;
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

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Diabhelp.Modules.Glucocompteur
{
    public sealed partial class GlucocompteurAddAliment : ContentDialog
    {
        private SQLiteConnection db;
        public String fieldObjectName = "alimentname";
        public String fieldObjectGlucides = "Glucides";
        public String tableName = "aliments_search";
        public List<Aliment> alimlist = new List<Aliment>();
        public Aliment selectedAliment { get; private set; }
        
        public GlucocompteurAddAliment()
        {
            this.InitializeComponent();
        }

        public void setDBContent(SQLiteConnection db)
        {
            this.db = db;
        }

        private List<Aliment> getAlimListFromDB(String input)
        {
            Debug.WriteLine("Try getAlimList for input: " + input);

            string sql = "";
            input = input.Replace("'", "''").Replace("\"", "\"\"");
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

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            double weight = 0.0;
            Double.TryParse(alimentQuantity.Text, out weight);
            selectedAliment.weight = weight;
            selectedAliment.totalGlucids = selectedAliment.weight * selectedAliment.Glucides / 100;
            alimentInput.Text = "";
            alimentQuantity.Text = "";
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            alimentInput.Text = "";
            alimentQuantity.Text = "";
        }
    }
}
