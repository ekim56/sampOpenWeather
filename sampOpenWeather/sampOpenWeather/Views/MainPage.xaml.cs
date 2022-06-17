using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net;
using sampOpenWeather.Models;

namespace sampOpenWeather
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            getOpenWeather();
        }
        string APIkey = "07795c1926651e85a707110092641b54";
        void getOpenWeather()
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q=Philippines,Manila&APPID=07795c1926651e85a707110092641b54", APIkey);
                var json = web.DownloadString(url);
                OpenWeatherInfoModel.alldata data = JsonConvert.DeserializeObject<OpenWeatherInfoModel.alldata>(json);
                weather.Text = data.weather[0].main;
                description.Text = data.weather[0].description;
                temp.Text = data.main.temp.ToString();
                Sunset.Text = data.sys.sunset.ToString();
                Sunrise.Text = data.sys.sunrise.ToString();
                windspeed.Text = data.wind.speed.ToString();
                pressure.Text = data.main.pressure.ToString();


            }

        }
    }
}
