using Diabhelp.Core.Api.ResponseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Diabhelp.Core.Api
{
    public class ApiClient
    {
        String baseUrl;
        HttpClient client;

        public ApiClient()
        {
            client = new HttpClient();
            baseUrl = "https://diabhelp.org/";
        }

        public async Task doLoginPost(string username, string password, Action<LoginResponseBody> callback)
        {
            Uri requestUri = new Uri(baseUrl + "rest-login");
            Debug.WriteLine("login with = " + username + ":" + password);

            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            };
            HttpFormUrlEncodedContent content = new HttpFormUrlEncodedContent(keyValues);
            HttpResponseMessage response = await client.PostAsync(requestUri, content);
            LoginResponseBody loginResponse = JsonConvert.DeserializeObject<LoginResponseBody>(response.Content.ToString());
            callback(loginResponse);
        }

        public async Task doGetInfo(int id_user, Action<GetProfileResponseBody> callback)
        {
            Uri requestUri = new Uri(baseUrl + "api/user/getInfo/" + id_user);
            Debug.WriteLine("getInfo for user : " + id_user);

            HttpResponseMessage response = await client.GetAsync(requestUri);
            GetProfileResponseBody getProfileResponse = JsonConvert.DeserializeObject<GetProfileResponseBody>(response.Content.ToString());
            callback(getProfileResponse);
        }

        public async Task doSetInfo(int id_user, string lastName, string firstName, long birthdateTimestamp, string email, string phone, string organisme,  string password, Action<SetProfileResponseBody> callback)
        {
            Uri requestUri = new Uri(baseUrl + "api/user/setInfo");
            Debug.WriteLine("setInfo for user : " + id_user);

            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("id", id_user.ToString()),
                new KeyValuePair<string, string>("lastname", lastName),
                new KeyValuePair<string, string>("firstname", firstName),
                new KeyValuePair<string, string>("birthday", birthdateTimestamp.ToString()),
                new KeyValuePair<string, string>("email", email),
                new KeyValuePair<string, string>("phone", phone),
                new KeyValuePair<string, string>("organisme", organisme)
            };
            if (!string.IsNullOrWhiteSpace(password))
                keyValues.Add(new KeyValuePair<string, string>("password", password));

            HttpFormUrlEncodedContent content = new HttpFormUrlEncodedContent(keyValues);
            HttpResponseMessage response = await client.PostAsync(requestUri, content);
            SetProfileResponseBody setProfileResponse = JsonConvert.DeserializeObject<SetProfileResponseBody>(response.Content.ToString());
            callback(setProfileResponse);
        }

        public async Task doInscription(string username, string email, string password, string role, string firstname, string lastname, Action<InscriptionResponseBody> callback)
        {
            Uri requestUri = new Uri(baseUrl + "api/user/register");
            Debug.WriteLine("register for = " + username + ":" + password);

            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("email", email),
                new KeyValuePair<string, string>("role", role),
                new KeyValuePair<string, string>("firstname", firstname),
                new KeyValuePair<string, string>("lastname", lastname)
            };
            HttpFormUrlEncodedContent content = new HttpFormUrlEncodedContent(keyValues);
            HttpResponseMessage response = await client.PostAsync(requestUri, content);
            Debug.WriteLine(response.Content);
            InscriptionResponseBody inscriptionResponse = JsonConvert.DeserializeObject<InscriptionResponseBody>(response.Content.ToString());
            callback(inscriptionResponse);
        }
    }
}

