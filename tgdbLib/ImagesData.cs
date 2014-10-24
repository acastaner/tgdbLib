using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using tgdbLib.Image;

namespace tgdbLib
{
    [XmlRoot("Data")]
    public class ImagesData
    {
        [XmlElement("baseImgUrl")]
        public string BaseImageUrl { get; set; }
        [XmlArray("Images")]
        [XmlArrayItem("fanart", Type = typeof(Fanart))]
        [XmlArrayItem("boxart", Type = typeof(Boxart))]
        [XmlArrayItem("clearlogo", Type = typeof(ClearLogo))]
        [XmlArrayItem("banner", Type = typeof(Banner))]
        public List<Image.Image> Images { get; set; }
    }
}
