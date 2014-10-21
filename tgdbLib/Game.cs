using System;
using System.Collections.Generic;
using System.Globalization;
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
        // We need to go through a proxy property for the release date as the returned value is not standard
        [XmlIgnore]
        public DateTime ReleaseDate { get; set; }
        [XmlElement("ReleaseDate")]
        public string ProxyDateTime
        {
            get { return ReleaseDate.ToString("MM/dd/yyyy"); }
            set { this.ReleaseDate = DateTime.ParseExact(value, "MM/dd/yyyy", CultureInfo.InvariantCulture); }
        }
        public string Overview { get; set; }
        public string ESRB { get; set; }
        public List<Genre> Genres { get; set; }
        public string Players { get; set; }
        public bool Coop { get; set; }
        public string Youtube { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public float Rating { get; set; }
        public List<Image.Image> Images { get; set; }

        public Game()
        {
            this.Genres = new List<Genre>();
            this.Images = new List<Image.Image>();
        }
    }
}
