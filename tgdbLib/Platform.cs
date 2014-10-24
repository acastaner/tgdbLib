using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace tgdbLib
{
    public class Platform
    {
        [XmlElement("id")]
        public int Id { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("alias")]
        public string Alias { get; set; }

        /// <summary>
        /// Returns a list of all the platforms.
        /// </summary>
        /// <returns></returns>
        public static List<Platform> GetPlatformsList()
        {
            RequestHelper helper = new RequestHelper();
            XmlDocument response = helper.MakeRequest("GetPlatformsList.php");
            PlatformsData data = helper.Deserialize<PlatformsData>(response);
            return data.Platforms;
        }
    }
}
