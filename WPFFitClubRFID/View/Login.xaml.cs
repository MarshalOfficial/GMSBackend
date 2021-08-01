using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window 
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Login_Button(object sender, RoutedEventArgs e)
        {
            string Username = user.Text;
            string Password = pass.Password;

           
            var Client = new RestClient(ConfigurationManager.AppSettings["api"].ToString());

            var request = new RestRequest("api/Account/login", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddBody(new LoginRequest() { user_name = Username, password = Password });

            var response = await Client.ExecutePostTaskAsync<LoginResult>(request);

            string a = response.Data.access_token ;
            string U = response.Data.user_name;
            App.accesstoken = a;

            if (Username == U)
            {
                MainWindow showmainwindow = new MainWindow();
                this.Visibility = Visibility.Hidden;
                showmainwindow.Show();
            }
            else if (Username == "" || Password == "")
            {
                MessageBox.Show(". لطفا نام کاربری و رمز عبور خود را وارد کنید");
            }
            else
            {
                MessageBox.Show(". نام کاربری یا رمز عبور اشتباه است");
            }
        }
    }
}
