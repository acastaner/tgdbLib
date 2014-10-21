using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace tgdbLib.Image
{
    public class Banner : Image
    {
        [XmlText]
        public string Url { get; set; }
    }
}
