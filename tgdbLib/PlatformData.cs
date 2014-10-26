using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace tgdbLib
{
    /// <summary>
    /// Wrapper class for queries returning PlatformDetails objects.
    /// </summary>
    [XmlRoot("Data")]
    public class PlatformData
    {
        [XmlElement("baseImgUrl")]
        public string BaseUrl { get; set; }
        public PlatformDetail Platform { get; set; }
    }
}
