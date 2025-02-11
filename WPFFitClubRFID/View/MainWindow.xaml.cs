﻿using MD.PersianDateTime.Standard;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Configuration;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using WPFFitClubRFID.Models;
using DataFormat = RestSharp.DataFormat;

namespace WPFFitClubRFID
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer Timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void Barcode_KeyUp(object sender, KeyEventArgs e)
        {
            string code = Barcode.Text;
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                var Client = new RestClient(ConfigurationManager.AppSettings["api"].ToString());

                var act = App.accesstoken;

                var aut = new JwtAuthenticator(act);
                Client.Authenticator = aut;

                var request = new RestRequest("api/Customer/rfid_seach_customer", Method.GET);
                request.AddParameter("barcode", code , ParameterType.QueryString);

                var response = await Client.ExecuteGetTaskAsync<CoreResponse>(request);

                var devmessage = response.Data.dev_message;

                if ( response.Data.is_success == true && devmessage == null )
                {
                    long customerid = response.Data.data[0].customer_id;
                    long saleinvoicedetailsid = response.Data.data[0].sale_invoice_details_log;

                    var authentication = new JwtAuthenticator(act);
                    Client.Authenticator = authentication;

                    var requesttt = new RestRequest("api/ClientSessionUsage/add_client_session_usage_kiosk", Method.POST);
                    
                    requesttt.RequestFormat = DataFormat.Json;
                    requesttt.AddBody(new ClientSessionUsageModel() { customer_id = customerid ,  sale_invoice_details_id = saleinvoicedetailsid ,description = "by RFID" , is_use = true });

                    var result = await Client.ExecutePostTaskAsync<CoreResponse>(requesttt);
                    var r = result.Data.is_success;
                    var dm = result.Data.dev_message;
                    Timer.Tick += new EventHandler(Timer_Tick);
                    Timer.Interval = new TimeSpan(0, 0, 180);

                    if ( r == true && dm == null)
                    {
                        var issuccess = result.Data.is_success;
                        bool gender = response.Data.data[0].gender;
                        int qty = result.Data.data[0].qty;
                        var firstName = response.Data.data[0].first_name;
                        var lastName = response.Data.data[0].last_name;
                        int sessionused = response.Data.data[0].session_used;
                        int sessionqty = response.Data.data[0].session_qty;
                        var str = new PersianDateTime(DateTime.Now);
                        
                        if ( gender == true)
                        {
                            re.Content = "آقای " + firstName + " " + lastName + " به استودیو فیت کلاب خوش آمدید ";
                            su.Content = " جلسه " + (sessionused + qty) + " از " + sessionqty;
                            lt.Content = " تاریخ : " + str;
                            Barcode.Text = string.Empty;
                            Timer.Start();
                        }
                        else if (gender == false)
                        {
                            re.Content = "خانم " + firstName + " " + lastName + " به استودیو فیت کلاب خوش آمدید ";
                            su.Content = " جلسه " + (sessionused + qty) + " از " + sessionqty;
                            lt.Content = " تاریخ : " + str;
                            Barcode.Text = string.Empty;
                            Timer.Start();
                        }
                        else
                        {
                            re.Content = "خطای نامشخص";
                            Barcode.Text = string.Empty;
                            su.Content = string.Empty;
                            lt.Content = string.Empty;
                            Timer.Start();
                        }
                    }
                    else
                    {
                        re.Content = dm;
                        Barcode.Text = string.Empty;
                        su.Content = string.Empty;
                        lt.Content = string.Empty;
                        Timer.Start();
                    }
                }
                else
                {
                    re.Content = devmessage;
                    Barcode.Text = string.Empty;
                    su.Content = string.Empty;
                    lt.Content = string.Empty;
                    Timer.Start();
                }
            }
        }

        private void addbarcode_Click(object sender, RoutedEventArgs e)
        {
            Addbarcoduser addbar = new Addbarcoduser();
            addbar.ShowDialog();
            Barcode.Focus();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
          re.Content = string.Empty;
          su.Content = string.Empty;
          lt.Content = string.Empty;
          Timer.Stop();
        }
    }
}
