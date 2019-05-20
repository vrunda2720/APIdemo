using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using static APIDemo.TempResponse;

namespace APIDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields

        private static string apiKey = "wUMCvkwaCRBPrkhib8jTi6GqVRnv3p";

        private string timeapi = "https://www.amdoren.com/api/timezone.php?api_key="+apiKey+"&city={0}";

        private string tempapi = "https://api.openweathermap.org/data/2.5/weather?appid=86c7e77118132ec90c94b1fe1fbe2e07&units=metric&q={0}";

        private string currencyapi = "https://www.amdoren.com/api/currency.php?api_key=" + apiKey + "&amount={0}&from={1}&to={2}";


        #endregion

        #region Property

        public string City { get; set; }
        public int Amount { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Events
        private void BtnTimeTemp_Click(object sender, RoutedEventArgs e)
        {
            //Why ? Get textbox value and store it in City Property
            City = boxcity.Text;
            //Call method to get time , save time in local variable "string time"
            string time = GetTime(City);
            //Call method to get temp, save temp in local variable "string temp"
            double temp = GetTemp(City);

            //Set timebox text to value provided in local variable "time"
            boxtime.Text = time;
            //Set tempbox text to value provided in local variable "temp"
            boxtemp.Text = temp.ToString();

        }

        private void BtnCurrency_Click(object sender, RoutedEventArgs e)
        {
            Amount =Convert.ToInt32(boxamount.Text);
            From = comboboxfrom.Text;
            To = comboboxto.Text;

            //call method to get amount,save amount in local variable "int amount"
            double amount2 = GetCurrency(Amount);

            //set amountbox value in local variable "amount2"
            boxconverted.Text = amount2.ToString();
        }
        #endregion
            
        #region Methods

        public string GetTime(string city)
        {
            
            string url = String.Format(timeapi, city);
            string response = new WebClient().DownloadString(url);
            TimeResponse tres = JsonConvert.DeserializeObject<TimeResponse>(response);
            return tres.time;

          
        }

        public double GetTemp(string city)
        {
            
            string url = string.Format(tempapi, city);
            string respose = new WebClient().DownloadString(url);
            TempResponse tempres = JsonConvert.DeserializeObject<TempResponse>(respose);
            return tempres.main.temp;
        }

        public double GetCurrency(int amount)
        {
            string url = string.Format(currencyapi, amount, From, To);
            string response = new WebClient().DownloadString(url);
            CurrencyResonse cres = JsonConvert.DeserializeObject<CurrencyResonse>(response);
            return cres.amount;
        }

        #endregion
    }
}
