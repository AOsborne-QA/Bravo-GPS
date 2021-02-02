

using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Radar.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HubConnection connection;
        public MainWindow()
        {
            InitializeComponent();
                //this sets up the initial connection, need to pass in the URL
            connection = new HubConnectionBuilder().WithUrl("https://localhost:44383/alertHub").Build();

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
            connection.On<string, string, string, DateTime>("RecieveAlert", (vehicleID, alertColour, alertType, timeStamp) =>
              {
                  this.Dispatcher.Invoke(() =>
                  {

                      if (alertColour == "Red")
                      {
                          if (alertType == "Temperature")
                          {
                              TemperatureAlert.Background = new LinearGradientBrush(Colors.Red, Colors.Crimson, 90);
                          }
                          if (alertType == "Humidity")
                          {
                              HumidityAlert.Background = new LinearGradientBrush(Colors.Red, Colors.Crimson, 90);
                          }
                      }

                    //picks up what colour the alert is, and then sets the specified alert to that colour
                });
              });

        }


    }
}
