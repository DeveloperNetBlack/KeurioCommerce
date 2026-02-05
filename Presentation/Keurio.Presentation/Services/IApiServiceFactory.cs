namespace Keurio.Presentation.Services
{
    public interface IApiServiceFactory
    {
        ApiService Create(string httpClientNamed);
    }
}
