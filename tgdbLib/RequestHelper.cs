using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace tgdbLib
{
    public class RequestHelper
    {
        private static string _baseUrl = " http://thegamesdb.net/api/";
        public RequestHelper() { }

        public Game GetGame(int Id)
        {
            XmlDocument response = MakeRequest(_baseUrl + "GetGame.php?id=" + Id);
            XmlSerializer serializer = new XmlSerializer(typeof(Data));
            XmlReader reader = new XmlNodeReader(response);

            Data data = (Data)serializer.Deserialize(reader);

            return data.Game;
        }

        private static XmlDocument MakeRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
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
