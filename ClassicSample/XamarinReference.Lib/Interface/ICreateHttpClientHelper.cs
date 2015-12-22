using System.Net.Http;

namespace XamarinReference.Lib.Interface
{
    public interface ICreateHttpClientHelper
    {
        HttpClientHandler CreateHandler();
    }
}