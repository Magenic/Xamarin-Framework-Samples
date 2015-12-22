using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XamarinReference.Lib.Model.iTunes
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
        [JsonProperty("height")]
        public string Height { get; set; }
    }

    public class ImImage
    {

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class Summary
    {
        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public class ImRentalPrice
    {

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class ImPrice
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

    public class ImArtist
    {

        [JsonProperty("label")]
        public string Label { get; set; }
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

        [JsonProperty("im:image")]
        public List<ImImage> ImImage { get; set; }

        [JsonProperty("summary")]
        public Summary Summary { get; set; }

        [JsonProperty("im:rentalPrice")]
        public ImRentalPrice ImRentalPrice { get; set; }

        [JsonProperty("im:price")]
        public ImPrice ImPrice { get; set; }

        [JsonProperty("im:contentType")]
        public ImContentType ImContentType { get; set; }

        [JsonProperty("title")]
        public Title Title { get; set; }

        [JsonProperty("link")]
        public List<Link> Link { get; set; }

        [JsonProperty("id")]
        public Id Id { get; set; }

        [JsonProperty("im:artist")]
        public ImArtist ImArtist { get; set; }

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
        public List<Entry> Entry { get; set; }

        [JsonProperty("updated")]
        public Updated Updated { get; set; }

        [JsonProperty("rights")]
        public Rights Rights { get; set; }

        [JsonProperty("title")]
        public Title Title { get; set; }

        [JsonProperty("icon")]
        public Icon Icon { get; set; }

        [JsonProperty("link")]
        public List<Link> Link { get; set; }

        [JsonProperty("id")]
        public Id Id { get; set; }
    }

    public class Movie 
    {

        [JsonProperty("feed")]
        public Feed Feed { get; set; }

        public enum ListingType
        {
            TopMovies,
            TopRentals,
        }
    }


    public class MovieCategory
    {
        public Dictionary<string, string> Categories { get; set; }

        public MovieCategory()
        {
            this.Categories = new Dictionary<string, string>();
            this.Categories.Add("Action & Adventure", "4401");
            this.Categories.Add("African", "4434");
            this.Categories.Add("All", "0");
            this.Categories.Add("Anime", "4402");
            this.Categories.Add("Bollywood", "4431");
            this.Categories.Add("Classics", "4403");
            this.Categories.Add("Comedy", "4404");
            this.Categories.Add("Concert Films", "4422");
            this.Categories.Add("Documentary", "4405");
            this.Categories.Add("Drama", "4403");
            this.Categories.Add("Foreign", "4407");
            this.Categories.Add("Holiday", "4420");
            this.Categories.Add("Horror", "4408");
            this.Categories.Add("Independent", "4409");
            this.Categories.Add("Japanese Cinema", "4425");
            this.Categories.Add("Jidaigeki", "4426");
            this.Categories.Add("Kids & Family", "4410");
            this.Categories.Add("Korean Cinema", "4428");
            this.Categories.Add("Made for TV", "4421");
            this.Categories.Add("Middle Eastern", "4433");
            this.Categories.Add("Music Documentaries", "4423");
            this.Categories.Add("Music Feature Films", "4424");
            this.Categories.Add("Musicals", "4411");
            this.Categories.Add("Regional Indian", "4432");
            this.Categories.Add("Romance", "4412");
            this.Categories.Add("Russian", "4429");
            this.Categories.Add("Sci-Fi & Fantasy", "4413");
            this.Categories.Add("Short Films", "4414");
            this.Categories.Add("Special Interest", "4415");
            this.Categories.Add("Sports", "4417");
            this.Categories.Add("Thriller", "4416");
            this.Categories.Add("Tokusatsu", "4427");
            this.Categories.Add("Turkish", "4430");
            this.Categories.Add("Urban", "4419");
            this.Categories.Add("Western", "4418");
        }
    }

}
