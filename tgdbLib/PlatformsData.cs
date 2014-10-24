using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace tgdbLib
{
    [XmlRoot("Data")]
    public class PlatformsData
    {
        [XmlElement("basePlatformUrl")]
        public string BaseUrl { get; set; }
        public List<Platform> Platforms { get; set; }
    }
}
