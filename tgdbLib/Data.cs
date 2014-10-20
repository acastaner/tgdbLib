using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace tgdbLib
{
    [XmlRoot("Data")]
    public class Data
    {
        [XmlElement("baseImgUrl")]
        public string BaseImgUrl { get; set; }
        [XmlElement("Game")]
        public Game Game { get; set; }
    }
}