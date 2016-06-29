using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
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

      
        private async void connect_button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("login_clicked ok");
            HttpClient client = new HttpClient();

            try
            {
                TextBox login = (TextBox)login_input;
                TextBox password = (TextBox)pass_input;
              
                HttpResponseMessage response = await client.GetAsync("http://www.naquedounet.fr/");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(responseBody);
                if (responseBody != "")
                {
                    this.Frame.Navigate(typeof(ModulesScreen));
                }
            } catch(HttpRequestException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
