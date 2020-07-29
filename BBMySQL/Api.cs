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
using System.Xml.Serialization;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Xml;

namespace BBMySQL
{
    class Api
    {
        

        public static async Task PostProject(Project project)
        {

            var baseAddress = new Uri("https://b3722b455a.fra2.easyredmine.com/");
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {

                XmlSerializer xs = null;

                //These are the objects that will free us from extraneous markup.
                XmlWriterSettings settings = null;
                XmlSerializerNamespaces ns = null;

                //We use a XmlWriter instead of a StringWriter.
                XmlWriter xw = null;

                String outString = String.Empty;

                settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;

                //To get rid of the default namespaces we create a new
                //set of namespaces with one empty entry.
                ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                StringBuilder sb = new StringBuilder();

                xs = new XmlSerializer(project.GetType());

                //We create a new XmlWriter with the previously created settings 
                //(to OmitXmlDeclaration).
                xw = XmlWriter.Create(sb, settings);

                //We call xs.Serialize and pass in our custom 
                //XmlSerializerNamespaces object.
                xs.Serialize(xw, project, ns);

                xw.Flush();

                outString = sb.ToString();
                using (var content = new StringContent(outString, System.Text.Encoding.Default, "application/xml"))
                {
                    using (var response = await httpClient.PostAsync("projects.xml?key=b17e9372ec58cd8a17190f83c8084bc9321ca12a", content))
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                    }
                }
                

            }
        }

    }
    
}

