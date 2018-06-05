using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace GraphQL_NET
{
    public class GraphQLNETClient
    {
        public object Execute(string path,string query)
        {
            
            var auth                      = System.Text.Encoding.UTF8.GetBytes("f30e4f25cc673e06e3b4f05ae8bf4b80" + ":" + "6bf5f6d74a09469c4c1ffb7f4ec53ff4");
            string auth64                 = Convert.ToBase64String(auth);
            HttpWebRequest request        = (HttpWebRequest)WebRequest.Create(path);
            request.ContentType           = "application/graphql";
            request.Method                = "POST";

          //  request.Headers.Add("Authorization", "Basic " + auth64);
            request.Headers.Add("X-Shopify-Access-Token", "6bf5f6d74a09469c4c1ffb7f4ec53ff4");

            if (query != null)
            {
             
                    if (!String.IsNullOrEmpty(query))
                    {
                        using (var ms = new MemoryStream())
                        {
                            using (var writer = new StreamWriter(request.GetRequestStream()))
                            {
                                writer.Write(query);
                                writer.Close();
                            }
                        }
                    }
            }

            var response = (HttpWebResponse)request.GetResponse();

            string result = null;
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                result = reader.ReadToEnd();
                reader.Close();
            }

            if (string.IsNullOrWhiteSpace(result))
                return null;

          return JsonConvert.DeserializeObject(result);

            
        }

        
    }
}
