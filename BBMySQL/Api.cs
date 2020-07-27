using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace BBMySQL
{
    class Api
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task PostProject(Project project)
        {            
            WebRequest request = WebRequest.Create("https://b3722b455a.fra2.easyredmine.com/projects.xml?key=b17e9372ec58cd8a17190f83c8084bc9321ca12a");// Create a request using a URL that can receive a post. 
            

            request.Method = "POST";// Set the Method property of the request to POST.

            string jsonData = JsonConvert.SerializeObject(project);
            var data = new StringContent(jsonData, Encoding.UTF8, "application/xml");

            var url = "https://b3722b455a.fra2.easyredmine.com/projects.xml?key=b17e9372ec58cd8a17190f83c8084bc9321ca12a";
            var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);


            
        }
    }
}
