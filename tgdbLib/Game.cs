using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace tgdbLib
{
    public class Game
    {
        [XmlElement("id")]
        public int Id { get; set; }
        public string GameTitle { get; set; }
        public int PlatformId { get; set; }
        public string Platform { get; set; }
        //public DateTime ReleaseDate { get; set; }
        public string Overview { get; set; }
        public string ESRB { get; set; }
        //public ICollection<string> Genres { get; set; }
        public string Players { get; set; }
        public bool Coop { get; set; }
        public string Youtube { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public float Rating { get; set; }
        /*public ICollection<Image.Image> Images { get; set; }*/
    }
}
