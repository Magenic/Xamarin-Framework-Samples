using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinReference.Lib.Model.iTunes;

namespace XamarinReference.Lib.Interface
{
    public interface IITunesDataService
    {
        Task<Movie> GetMoviesAsync(Movie.ListingType type, int count, string genre);

        List<string> GetMovieGenres();
    }
}