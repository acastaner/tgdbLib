using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace tgdbLib.Image
{
    public class Fanart : Image
    {
        [XmlElement("original")]
        public string Original { get; set; }
        [XmlElement("thumb")]
        public string Thumb { get; set; }
    }
}
