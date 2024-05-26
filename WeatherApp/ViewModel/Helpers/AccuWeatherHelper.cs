using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel.Helpers;
public class AccuWeatherHelper
{
    public const string BASE_URL = "http://dataservice.accuweather.com/";        
    public const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
    public const string CURRENT_CONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";
    public const string API_KEY = "MZaF0koG4NYwQd6VP3DwJuR0ObjDA5W9";
    // 265318
    public static async Task<List<City>> GetCities(string query)
    {
        List<City> cities = new List<City>();

        string url = BASE_URL + string.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, query);

        using(HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                cities = (List<City>)JsonConvert.DeserializeObject(json, typeof(List<City>));
            }
        }

        return cities;
        //return string.Format(BASE_URL + AUTOCOMPLETE_ENDPOINT, API_KEY, query);
    }

    public static async Task<CurrentConditions> GetCurrentConditions(string cityKey)
    {
        CurrentConditions currentConditions = new CurrentConditions();

        string url = BASE_URL + string.Format(CURRENT_CONDITIONS_ENDPOINT, cityKey, API_KEY);

        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                currentConditions = (CurrentConditions)JsonConvert.DeserializeObject(json, typeof(CurrentConditions));
            }
        }

        return currentConditions;
    }


}
