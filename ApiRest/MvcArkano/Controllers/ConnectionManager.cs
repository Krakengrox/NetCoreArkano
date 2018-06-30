using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcArkano.Models;
using System.Net.Http;
using ApiRest.Modelos;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;


namespace McvArkano.Controllers
{
    /// <summary>
    /// Manejador de conexiones por medio de HTTPCLIENT
    /// URL del servicio: http://apirestarkanotest.azurewebsites.net/
    /// </summary>
    public static class ConnectionManager
    {
        /// <summary>
        /// Método get
        /// </summary>
        /// <returns></returns>
        public static List<Computer> GetComputers()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://apirestarkanotest.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("api/Computer").Result;
                if (response.IsSuccessStatusCode)
                {

                    var json = response.Content.ReadAsStringAsync().Result;
                    List<Computer> computers = JsonConvert.DeserializeObject<List<Computer>>(json);
                    return computers;
                }

            }

            return new List<Computer>();
        }

        /// <summary>
        /// Método post
        /// </summary>
        /// <param name="computer"></param>
        /// <returns></returns>
        public static Computer PostComputers(Computer computer)
        {

            //computer = new Computer() { memory = 15, processor = "50", diskType = 20 };
            //var httpClient = new HttpClient();
            //var json = JsonConvert.SerializeObject(computer);
            //HttpContent content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            //var result = httpClient.PostAsync("http://apirestarkanotest.azurewebsites.net/api/Computer", content).Result;
            //return computer;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://apirestarkanotest.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var json = JsonConvert.SerializeObject(computer);
                HttpContent content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

                var response = client.PostAsync("api/Computer", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = response.Content.ReadAsStringAsync().Result;
                    Computer computers = JsonConvert.DeserializeObject<Computer>(jsonResponse);
                    return computers;
                }
            }

            return null;
        }


    }
}
