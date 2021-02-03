using Microsoft.AspNetCore.SignalR.Client;
using Radar.Library;
using Radar.Library.Models.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Radar.Library.Models.ViewModel;
using Radar.Library.Models.Binding;

namespace Radar.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HubConnection connection;
        HttpClient client;
        string path;
        public MainWindow()
        {
            InitializeComponent();
                //this sets up the initial connection to signalR, need to pass in the URL
            connection = new HubConnectionBuilder().WithUrl("https://localhost:44383/alertHub").Build();

            //this sets up the connection to the API
            client = new HttpClient();
            path = "https://localhost:44383/api/vehicle/";

            connection.Reconnecting += error =>
            {
                Debug.Assert(connection.State == HubConnectionState.Reconnecting);
                return Task.CompletedTask;
            };
            connection.Reconnected += connectionId =>
            {
                Debug.Assert(connection.State == HubConnectionState.Connected);
                return Task.CompletedTask;
            };
            connection.Closed += error =>
            {
                Debug.Assert(connection.State == HubConnectionState.Disconnected);
                return Task.CompletedTask;
            };
        }
        private async void connectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //tries an initial connection
                await connection.StartAsync();
                //puts the message in the connection box
                ConnectBox.Text = "Connected";
                ConnectButton.IsEnabled = false;
            }
            catch(Exception exc)
            {
                //puts the error message in the connection box if the connection fails
                ConnectBox.Text =(exc.Message);
            }
            connection.On<Alert>("RecieveAlert", (alert) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    VehilceIDBox.Text = alert.VehicleID.ToString();
                    HumidityBox.Text = alert.VehicleHumidity.ToString();
                    TemperatureBox.Text = alert.VehicleTemp.ToString();
                    LatitudeBox.Text = alert.Latitude.ToString();
                    LongitudeBox.Text = alert.Longitude.ToString();
                    TimeStampBox.Text = alert.AlertTime.ToString();
                    if (alert.AlertColour == "Red")
                    {
                        if (alert.AlertType == "Temperature")
                        {
                            TemperatureLabel.Background = new LinearGradientBrush(Colors.Red, Colors.Crimson, 90);
                        }
                        if (alert.AlertType == "Humidity")
                        {
                            HumidityLabel.Background = new LinearGradientBrush(Colors.Red, Colors.Crimson, 90);
                        }
                    }
                    else if (alert.AlertColour == "Amber")
                    {
                        if (alert.AlertType == "Temperature")
                        {
                            TemperatureLabel.Background = new LinearGradientBrush(Colors.Orange, Colors.DarkOrange, 90);
                        }
                        if (alert.AlertType == "Humidity")
                        {
                            HumidityLabel.Background = new LinearGradientBrush(Colors.Orange, Colors.DarkOrange, 90);
                        }
                    }
                    else if (alert.AlertColour == "Green")
                    {
                        if (alert.AlertType == "Temperature")
                        {
                            TemperatureLabel.Background = new LinearGradientBrush(Colors.Green, Colors.DarkGreen, 90);
                        }
                        if (alert.AlertType == "Humidity")
                        {
                            HumidityLabel.Background = new LinearGradientBrush(Colors.Green, Colors.DarkGreen, 90);
                        }
                    }

                    //picks up what colour the alert is, and then sets the specified alert to that colour
                });
            });

        }
        private async void GetButton_Click(object sender ,RoutedEventArgs e)
        {
            Vehicle vehicle = new Vehicle();
            VehicleViewModel vView = new VehicleViewModel();
     
            string vehicleID = GetIdBox.Text;
            Uri route = new Uri(path + "status/" + vehicleID);
            HttpResponseMessage response = await client.GetAsync(route);
            if (response.IsSuccessStatusCode)
            {
                vView = response.Content.ReadAsAsync<VehicleViewModel>().Result;
                vehicle = vView.Vehicle;
            }
            GetHumidityBox.Text = vehicle.VehicleHumidity.ToString();
            GetTemperatureBox.Text = vehicle.VehicleTemp.ToString();
            GetLatitudeBox.Text = vehicle.Latitude.ToString();
            GetLongitudeBox.Text = vehicle.Longitude.ToString();

        }

        public async void GetAllButton_Click(object sender, RoutedEventArgs e)
        {
            Vehicle vehicle = new Vehicle();
            List<VehicleViewModel> vView = new List<VehicleViewModel>();
            Uri route = new Uri(path + "status/all");
            HttpResponseMessage response = await client.GetAsync(route);
            if (response.IsSuccessStatusCode)
            {
                vView = response.Content.ReadAsAsync<List<VehicleViewModel>>().Result;
            }
            foreach(var a in vView)
            {
                GetAllBox.Items.Add(a.Vehicle.VehicleID);
                string T = ("Temperature: " + a.Vehicle.VehicleTemp.ToString());
                GetAllBox.Items.Add(T);
                string H = ("Humidity: " + a.Vehicle.VehicleHumidity.ToString());
                GetAllBox.Items.Add(H);
            }
        }
        public async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            VehicleViewModel vView = new VehicleViewModel();
            string vehicleID = UpdateIDBox.Text;
            Uri route = new Uri(path + "status/" + vehicleID);
            HttpResponseMessage response = await client.GetAsync(route);
            if (response.IsSuccessStatusCode)
            {
                vView = response.Content.ReadAsAsync<VehicleViewModel>().Result;
            }

            route = new Uri(path + "update/" + vView.Vehicle.VehicleID);
            vView.Vehicle.VehicleHumidity = float.Parse(UpdateHumidityBox.Text);
            vView.Vehicle.VehicleTemp = float.Parse(UpdateTemperatureBox.Text);

            UpdateVehicle updateVehicle = new UpdateVehicle()
            {
                VehicleHumidity = vView.Vehicle.VehicleHumidity,
                VehicleTemp = vView.Vehicle.VehicleTemp,
                Latitude = vView.Vehicle.Latitude,
                Longitude = vView.Vehicle.Longitude
            };
            HttpResponseMessage UpdateResponse = await client.PutAsJsonAsync(route ,updateVehicle);

        }


    }
}
