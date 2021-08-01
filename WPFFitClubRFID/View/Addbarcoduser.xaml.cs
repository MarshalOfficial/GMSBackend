using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFFitClubRFID.Models;

namespace WPFFitClubRFID
{
    /// <summary>
    /// Interaction logic for Addbarcoduser.xaml
    /// </summary>
    public partial class Addbarcoduser : Window
    {
        public Account curentaccount { get; set; } = new Account();
        public Addbarcoduser()
        {
            InitializeComponent();
            getallusers();
           
        }
        
        public async void getallusers()
        {
            var act = App.accesstoken;

            var Client = new RestClient("http://localhost:8585/");

            var authentication = new JwtAuthenticator(act);
            Client.Authenticator = authentication;

            var request = new RestRequest("api/Customer/getCustomers", Method.GET);

            var response = await Client.ExecuteGetTaskAsync<CoreResponse>(request);

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["data"];

            var account = JsonConvert.DeserializeObject<List<Account>>(result);

            showusers.ItemsSource = account;
        }
 
        private void showusers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (showusers.SelectedIndex >= 0 )
            {
               curentaccount =  showusers.SelectedItem as Account ;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void AddBar_Click(object sender, RoutedEventArgs e)
        {
            if (showusers.SelectedIndex >= 0)
            {
                curentaccount = showusers.SelectedItem as Account;
                SetBarcode setBarcode = new SetBarcode(curentaccount);
                setBarcode.ShowDialog();

                var act = App.accesstoken;

                var Client = new RestClient("http://localhost:8585/");

                var authentication = new JwtAuthenticator(act);
                Client.Authenticator = authentication;

                var request = new RestRequest("api/Customer/getCustomers", Method.GET);

                var response = await Client.ExecuteGetTaskAsync<CoreResponse>(request);

                var deserialize = new JsonDeserializer();
                var output = deserialize.Deserialize<Dictionary<string, string>>(response);
                var result = output["data"];

                var account = JsonConvert.DeserializeObject<List<Account>>(result);


                showusers.ItemsSource = null;
                showusers.ItemsSource = account;

            }
        }
    }
}
