using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Bot.Weather
{
	public static class Weather
	{
		private static string url = "https://api.openweathermap.org/data/2.5/weather?q=Izhevsk&units=metric&appid=4cd34c6bc80b0194df845125612a44af";

		public static  WeatherResponse GettingWeather()

		{
			string responseText;
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			using (StreamReader reader = new StreamReader(response.GetResponseStream()))
			{
				responseText = reader.ReadToEnd();
			}
			var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseText);

			return weatherResponse;
		}
	}
}
