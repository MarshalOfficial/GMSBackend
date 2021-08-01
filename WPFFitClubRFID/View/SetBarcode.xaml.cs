using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using DataFormat = RestSharp.DataFormat;

namespace WPFFitClubRFID
{
    /// <summary>
    /// Interaction logic for SetBarcode.xaml
    /// </summary>
    public partial class SetBarcode : Window
    {
        private Account editinguser;
        private RestSharp.DataFormat dataformat;

        public SetBarcode(Account ac)
        {
            InitializeComponent();
            editinguser = ac;
            tbbarcode.Text = editinguser.rfid_barcode;
            tbid.Text = editinguser.id.ToString();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void ok_Click(object sender, RoutedEventArgs e)
        {
            var act = App.accesstoken;
            long id = Convert.ToInt64(tbid.Text);
            string barcode = tbbarcode.Text;

            var Client = new RestClient(ConfigurationManager.AppSettings["api"].ToString());

            var authentication = new JwtAuthenticator(act);
            Client.Authenticator = authentication;

            var request = new RestRequest("api/Customer/BarcodeUpdate", Method.PUT);

            request.RequestFormat = DataFormat.Json;
            request.AddBody(new BarCodeUpdateModel() { id = id , rfid_barcode = barcode });

            var response = await Client.PutTaskAsync<CoreResponse>(request);

            this.Close();
        }
    }
}
