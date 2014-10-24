using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using tgdbLib.Image;

namespace tgdbLib
{
    public class RequestHelper
    {
        private static string _baseUrl = "http://thegamesdb.net/api/";
        public RequestHelper() { }

        public T Deserialize<T>(XmlDocument document)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlReader reader = new XmlNodeReader(document);
            T data = (T)serializer.Deserialize(reader);
            return data;
        }

        /// <summary>
        /// Retrieves the XML response of from The Game Database API.
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <returns></returns>
        public XmlDocument MakeRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(_baseUrl + requestUrl) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                return (xmlDoc);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
                return null;
            }
        }
    }
}
