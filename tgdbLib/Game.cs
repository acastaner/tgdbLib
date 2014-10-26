using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using tgdbLib.Image;

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
        [XmlElement("Genres")]
        public List<Genre> Genres { get; set; }
        public string Players { get; set; }
        public bool Coop { get; set; }
        public string Youtube { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public float Rating { get; set; }
        [XmlArray("Images")]
        [XmlArrayItem("fanart", Type = typeof(Fanart))]
        [XmlArrayItem("boxart", Type = typeof(Boxart))]
        [XmlArrayItem("clearlogo", Type = typeof(ClearLogo))]
        [XmlArrayItem("banner", Type = typeof(Banner))]
        public List<Image.Image> Images { get; set; }

        public Game()
        {
            this.Genres = new List<Genre>();
            this.Images = new List<Image.Image>();
        }

        /// <summary>
        /// Returns the game with the specified Id.
        /// </summary>
        /// <param name="id">The id of the game to return.</param>
        /// <returns></returns>
        public static Game Get(int id)
        {
            RequestHelper helper = new RequestHelper();
            XmlDocument response = helper.MakeRequest("GetGame.php?id=" + id);

            XmlSerializer serializer = new XmlSerializer(typeof(GameData));
            XmlReader reader = new XmlNodeReader(response);        
            GameData data = (GameData)serializer.Deserialize(reader);

            return data.Game;
        }
        /// <summary>
        /// Returns a list of games matching the specified name.
        /// </summary>
        /// <param name="name">Name of the game(s) to return.</param>
        /// <returns></returns>
        public static List<Game> Get(string name)
        {
            // TODO: This returns a non-nested list, need to investigate how to serialize that
            // ie: GetGame.php?name=XCOM 
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns a list of available artwork types and locations specific to the requested game id in the database.
        /// </summary>
        /// <param name="id">The numeric ID of the game in the database that you like to fetch artwork details for. </param>
        /// <returns></returns>
        public static List<tgdbLib.Image.Image> GetArt(int id)
        {
            RequestHelper helper = new RequestHelper();
            XmlDocument response = helper.MakeRequest("GetArt.php?id=" + id);

            XmlSerializer serializer = new XmlSerializer(typeof(ImagesData));
            XmlReader reader = new XmlNodeReader(response);
            ImagesData data = (ImagesData)serializer.Deserialize(reader);

            return data.Images;
        }
    }
}
