using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinReference.Lib.Interface;

namespace XamarinReference.Lib.Services
{
    public class ITunesDataService : BaseHttpService, IITunesDataService
    {
        private string _urlBase = "https://itunes.apple.com/us/rss/";
        private string _movieRentals = "/topvideorentals";
        private string _topMovies = "/topmovies";
        private string _topMusicVideos = "/topmusicvideos";
        private string _limit = "/limit=";
        private string _genre = "/genre=";


        public string GetMovieGenreByKey(string key)
        {
            try
            {
                return new Model.iTunes.Movies.MovieCategory().Categories.SingleOrDefault(x => x.Key == key).Value;
            }
            catch (Exception ex)
            {

                this.DealWithErrors(ex);
            }
            return string.Empty;
        }

        public string GetMusicViceoGenreByKey(string key)
        {
            try
            {
                return new Model.iTunes.MusicVideos.MusicVideoCategory().Categories.SingleOrDefault(x => x.Key == key).Value;
            }
            catch (Exception ex)
            {
                this.DealWithErrors(ex);
            }
            return string.Empty;
        }

        public List<string> GetMusicVideoGenres()
        {
            List<string> list = null;
            try
            {
                list = new Model.iTunes.MusicVideos.MusicVideoCategory().Categories.Select(x => x.Key).ToList();
            }
            catch (Exception ex)
            {
                this.DealWithErrors(ex);
            }
            return list;
        }

        public List<string> GetMovieGenres()
        {
            List<string> list = null;
            try
            {
                list = new Model.iTunes.Movies.MovieCategory().Categories.Select(x => x.Key).ToList();
            }
            catch (Exception ex)
            {
                this.DealWithErrors(ex);
            }
            return list;
        }

        public async Task<Model.iTunes.Movies.Movie> GetMoviesAsync(Model.iTunes.Movies.Movie.ListingType type = Model.iTunes.Movies.Movie.ListingType.TopMovies, int count = 20, string genre = "4413")
        {
            Model.iTunes.Movies.Movie movies = null;
            if (genre != "4413")
            {
                genre = this.GetMovieGenreByKey(genre);
            }
            try
            {
                var uri = BuildMoviesUrl(type, count, genre);
                var httpResponseMessage = await this.GetAsync(new Uri(uri), null);
                var response = httpResponseMessage;
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    movies = JsonConvert.DeserializeObject<Model.iTunes.Movies.Movie>(json);
                }
                else
                    response = (HttpResponseMessage)null;
            }
            catch (Exception ex)
            {
                this.DealWithErrors(ex);
            }
            return movies;
        }

        public string BuildMoviesUrl(Model.iTunes.Movies.Movie.ListingType type = Model.iTunes.Movies.Movie.ListingType.TopMovies, int limit = 0, string genre = "4413")
        {
            var stringBuilder = new StringBuilder(this._urlBase);
            if (type == Model.iTunes.Movies.Movie.ListingType.TopMovies)
                stringBuilder.Append(this._topMovies);
            else
                stringBuilder.Append(this._movieRentals);
            if (limit > 0)
            {
                stringBuilder.Append(this._limit);
                stringBuilder.Append(limit.ToString());
            }
            stringBuilder.Append(this._genre);
            stringBuilder.Append(genre);
            stringBuilder.Append("/json");
            return stringBuilder.ToString();
        }
    }
}
