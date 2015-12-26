using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XamarinReference.Lib.Model.iTunes.MusicVideos
{
    public class Name
    {
        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public class Uri
    {
        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public class Author
    {
        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("uri")]
        public Uri Uri { get; set; }
    }

    public class ImName
    {
        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public class Rights
    {
        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public class Attributes
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class ImPrice
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class ImImage
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class ImArtist
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class Title
    {
        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public class ImDuration
    {
        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public class Link
    {
        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }

        [JsonProperty("im:duration")]
        public ImDuration ImDuration { get; set; }
    }

    public class Id
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class ImContentType
    {
        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class Category
    {
        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class ImReleaseDate
    {
        [JsonProperty("label")]
        public DateTime Label { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class Entry
    {
        [JsonProperty("im:name")]
        public ImName ImName { get; set; }

        [JsonProperty("rights")]
        public Rights Rights { get; set; }

        [JsonProperty("im:price")]
        public ImPrice ImPrice { get; set; }

        [JsonProperty("im:image")]
        public IList<ImImage> ImImage { get; set; }

        [JsonProperty("im:artist")]
        public ImArtist ImArtist { get; set; }

        [JsonProperty("title")]
        public Title Title { get; set; }

        [JsonProperty("link")]
        public IList<Link> Link { get; set; }

        [JsonProperty("id")]
        public Id Id { get; set; }

        [JsonProperty("im:contentType")]
        public ImContentType ImContentType { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }

        [JsonProperty("im:releaseDate")]
        public ImReleaseDate ImReleaseDate { get; set; }
    }

    public class Updated
    {
        [JsonProperty("label")]
        public DateTime Label { get; set; }
    }

    public class Icon
    {
        [JsonProperty("label")]
        public string Label { get; set; }
    }


    public class Feed
    {
        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("entry")]
        public IList<Entry> Entry { get; set; }

        [JsonProperty("updated")]
        public Updated Updated { get; set; }

        [JsonProperty("rights")]
        public Rights Rights { get; set; }

        [JsonProperty("title")]
        public Title Title { get; set; }

        [JsonProperty("icon")]
        public Icon Icon { get; set; }

        [JsonProperty("link")]
        public IList<Link> Link { get; set; }

        [JsonProperty("id")]
        public Id Id { get; set; }
    }

    public class MusicVideo 
    {
        [JsonProperty("feed")]
        public Feed Feed { get; set; }
    }

    public class MusicVideoCategory
    {
        public Dictionary<string, string> Categories { get; set; }

        public MusicVideoCategory()
        {
            this.Categories = new Dictionary<string, string>();
            this.Categories.Add("Alternative ", "1620");
            this.Categories.Add("Anime ", "1629");
            this.Categories.Add("All", "0");
            this.Categories.Add("Blues", "1602");
            this.Categories.Add("Brazillian", "1671");
            this.Categories.Add("Children's Music", "1604");
            this.Categories.Add("Chinese", "1637");
            this.Categories.Add("Christian & Gospel", "1622");
            this.Categories.Add("Classical", "1605");
            this.Categories.Add("Comedy", "1603");
            this.Categories.Add("Country", "1606");
            this.Categories.Add("Dance", "1617");
            this.Categories.Add("Easy Listening", "1625");
            this.Categories.Add("Electronic", "1607");
            this.Categories.Add("Enka", "1628");
            this.Categories.Add("Fitness & Workout", "1683");
            this.Categories.Add("French Pop", "1632");
            this.Categories.Add("German Folk", "1634");
            this.Categories.Add("German Pop", "1633");
            this.Categories.Add("Hip-Hop/Rap", "1618");
            this.Categories.Add("Holiday", "1608");
            this.Categories.Add("Indian", "1690");
            this.Categories.Add("Instrumental", "1684");
            this.Categories.Add("J-Pop", "1627");
            this.Categories.Add("Jazz", "1611");
            this.Categories.Add("K-Pop", "1686");
            this.Categories.Add("Karaoke", "1687");
            this.Categories.Add("Kayokyoku", "1630");
            this.Categories.Add("Korean", "1648");
            this.Categories.Add("Latin", "1612");
            this.Categories.Add("New Age", "1613");
            this.Categories.Add("Opera", "1609");
            this.Categories.Add("Podcasts", "1626");
            this.Categories.Add("Pop", "1614");
            this.Categories.Add("R&B/Soul", "1615");
            this.Categories.Add("Reggae", "1624");
            this.Categories.Add("Rock", "1621");
            this.Categories.Add("Singer/Songwriter", "1610");
            this.Categories.Add("Soundtrack", "1616");
            this.Categories.Add("Spoken Word", "1689");
            this.Categories.Add("Vocal", "1632");
            this.Categories.Add("World", "1619");
        }
    }
}
