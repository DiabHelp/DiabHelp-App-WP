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
using Diabhelp.Core.Api;
using Diabhelp.Core.Api.ResponseModels;
using System.Threading.Tasks;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Diabhelp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginScreen : Page
    {
        public LoginScreen()
        {
            this.InitializeComponent();
        }

      
        public async void connect_button_Click(object sender, RoutedEventArgs e)
        {

            Debug.WriteLine("login_clicked ok");

            //this.Frame.Navigate(typeof(MainScreen));
            //return;

            string login = login_input.Text;
            string password = pass_input.Password;

            if (!string.IsNullOrWhiteSpace(login)  && !string.IsNullOrWhiteSpace(password))
            {
                await new ApiClient().doLoginPost(login, password, connect_button_callback);
            }
            else
            {
                error_lbl.Text = "Veuillez remplir tout les champs";
            }

        }
        public void connect_button_callback(LoginResponseBody response)
        {
            if (response.success)
            {
                error_lbl.Text = "";
                this.Frame.Navigate(typeof(MainScreen), response);
            }
            else
            {
                String errortext = "Erreur lors de la connection : ";
                if (response.errors.Count >= 1)
                    errortext += response.errors[0];
                else
                    errortext += "Erreur Inconnue";
                error_lbl.Text = errortext;
            }

        }

        private void inscription_button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Core.InscriptionScreen));
        }
    }
}
