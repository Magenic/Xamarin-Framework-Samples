using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinReference.Lib.Model;

namespace XamarinReference.Lib.Interface
{
    public interface IITunesDataService
    {
       
        Task<Model.iTunes.Movies.Movie> GetMoviesAsync(Model.iTunes.Movies.Movie.ListingType type, int count, string genre);

        Task<Model.iTunes.MusicVideos.MusicVideo> GetMusicVideosAsync(int count, string genre);

        List<string> GetMovieGenres();

        List<string> GetMusicVideoGenres();
    }
}