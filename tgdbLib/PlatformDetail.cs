using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using tgdbLib.Image;

namespace tgdbLib
{
    /// <summary>
    /// This classes contains the detailed informations about a platform. Not to be confused with the simpler Platform class.
    /// </summary>
    public class PlatformDetail
    {
        [XmlElement("id")]
        public int Id { get; set; }
        public string Platform { get; set; }
        [XmlElement("console")]
        public string Console { get; set; }
        [XmlElement("controller")]
        public string Controller { get; set; }
        [XmlElement("overview")]
        public string Overview { get; set; }
        [XmlElement("developer")]
        public string Developer { get; set; }
        [XmlElement("manufacturer")]
        public string Manufacturer { get; set; }
        [XmlElement("cpu")]
        public string Cpu { get; set; }
        [XmlElement("memory")]
        public string Memory { get; set; }
        [XmlElement("graphics")]
        public string Graphics { get; set; }
        [XmlElement("sound")]
        public string Sound { get; set; }
        [XmlElement("display")]
        public string Display { get; set; }
        [XmlElement("media")]
        public string Media { get; set; }
        [XmlElement("maxcontrollers")]
        public int MaxControllers { get; set; }
        public float Rating { get; set; }
        [XmlArray("Images")]
        [XmlArrayItem("fanart", Type = typeof(Fanart))]
        [XmlArrayItem("boxart", Type = typeof(Boxart))]
        [XmlArrayItem("clearlogo", Type = typeof(ClearLogo))]
        [XmlArrayItem("banner", Type = typeof(Banner))]
        [XmlArrayItem("consoleart", Type = typeof(ConsoleArt))]
        [XmlArrayItem("controllerart", Type = typeof(ControllerArt))]
        public List<Image.Image> Images { get; set; }

        public static PlatformDetail Get(int platformId)
        {
            RequestHelper helper = new RequestHelper();
            XmlDocument reponse = helper.MakeRequest("GetPlatform.php?id=" + platformId);
            PlatformData data = helper.Deserialize<PlatformData>(reponse);

            return data.Platform;
        }
    }
}
