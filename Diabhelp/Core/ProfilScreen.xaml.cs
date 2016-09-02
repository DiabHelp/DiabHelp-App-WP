using Diabhelp.Core.Api;
using Diabhelp.Core.Api.ResponseModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class ProfilScreen : Page
    {
        LoginResponseBody loginInfo;
        public ProfilScreen()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            Debug.WriteLine("ProfilScreen::OnNavigatedTo");
            loginInfo = e.Parameter as LoginResponseBody;
            new ApiClient().doGetInfo(loginInfo.id_user, getProfileInfoCallback);

        }

        public void getProfileInfoCallback (GetProfileResponseBody response)
        {
            if (response.success)
            {
                GetProfileResponseBody.User user = response.user;
                lastNameInput.Text = user.lastname;
                firstNameInput.Text = user.firstname;
                DateTime birthdate = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                if (user.birthdate != null)
                    birthdate = birthdate.AddSeconds(user.birthdate.Value);
                birthdateInput.Text = birthdate.ToString("dd/MM/yyyy");
                emailInput.Text = user.email;
                phoneInput.Text = user.phone;
                organismeInput.Text = user.organisme;
            }
 
        }

        public void setProfileInfoCallback (SetProfileResponseBody response)
        {
            if (response.success)
            {
                error_lbl.Text = "Changements validés !";
            }
        }


        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.profileGrid.Children.OfType<TextBox>().Any(t => string.IsNullOrWhiteSpace(t.Text)))
            {
                error_lbl.Text = "Veuillez remplir tout les champs";
            }
            else if (!passwordBox.Password.Equals(passwordconfirmBox.Password))
            {
                error_lbl.Text = "Les mots de passe doivent correspondre";
            }
            else
            {
                DateTime parsedDate;
                DateTime.TryParseExact(birthdateInput.Text, "dd/MM/yyyy", null, DateTimeStyles.None,out parsedDate);
                long birthdateTimestamp = parsedDate.Ticks - new DateTime(1970, 1, 1, 0, 0, 0, 0).Ticks;
                error_lbl.Text = "";
                new ApiClient().doSetInfo(loginInfo.id_user, lastNameInput.Text, firstNameInput.Text, birthdateTimestamp, emailInput.Text, phoneInput.Text, organismeInput.Text, passwordBox.Password, setProfileInfoCallback);
            }
        }
    }
}
