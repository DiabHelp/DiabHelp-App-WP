using Diabhelp.Core.Api;
using Diabhelp.Core.Api.ResponseModels;
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
    public sealed partial class InscriptionScreen : Page
    {
        public InscriptionScreen()
        {
            this.InitializeComponent();
        }

        private void inscription_confirm_button_Click(object sender, RoutedEventArgs e)
        {
            if (inscriptionPanel.Children.OfType<TextBox>().Any(t => string.IsNullOrWhiteSpace(t.Text)) ||
                inscriptionPanel.Children.OfType<PasswordBox>().Any(t => string.IsNullOrWhiteSpace(t.Password)) ||
                !role_panel.Children.OfType<RadioButton>().Any(b => b.IsChecked == true))
            {
                error_lbl.Text = "Veuillez remplir tout les champs";
            }
            else if (!password_input.Password.Equals(password_confirm_input.Password))
                error_lbl.Text = "Les mots de passe doivent correspondre";
            else if (login_input.Text.Length < 6)
                error_lbl.Text = "Le login doit faire au moins 6 caractères";
            else if (password_input.Password.Length < 6)
                error_lbl.Text = "Le mot de passe doit faire au moins 6 caractères";
            else
            {
                string role = "";
                if (patient_radio_btn.IsChecked == true)
                    role = "ROLE_PATIENT";
                else if (medecin_radio_btn.IsChecked == true)
                    role = "ROLE_DOCTOR";
                else
                    role = "ROLE_PROCHE";
                new ApiClient().doInscription(login_input.Text, email_input.Text, password_input.Password, role, firstname_input.Text, lastname_input.Text, inscription_button_callback);
            }
        }

        public async void inscription_button_callback(InscriptionResponseBody response)
        {
            if (response.success)
            {
                error_lbl.Text = "";
                await new ApiClient().doLoginPost(login_input.Text, password_input.Password, connect_after_inscription_button_callback);
            }
            else
            {
                String errortext = "Erreur lors de l'inscription : ";
                if (response.errors.Count >= 1)
                    errortext += response.errors[0];
                else
                    errortext += "Erreur Inconnue";
                error_lbl.Text = errortext;
            }
        }
        public void connect_after_inscription_button_callback(LoginResponseBody response)
        {
            if (response.success)
            {
                this.Frame.Navigate(typeof(MainScreen), response);
            }
            else
            {
                this.Frame.Navigate(typeof(LoginScreen));
            }
        }
    }
}