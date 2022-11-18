using Musharaf.Portal.Core.Blazor.Models.Configurations;
using RESTFulSense.Clients;

namespace Musharaf.Portal.Core.Blazor.Brokers.Apis
{
    public class ApiBroker : IApiBroker
    {
        private readonly IRESTFulApiFactoryClient apiClient;
        private readonly HttpClient httpClient;

        public ApiBroker(
            HttpClient httpClient, 
            IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.apiClient = GetApiClient(configuration);
        }

        private IRESTFulApiFactoryClient GetApiClient(IConfiguration configuration)
        {
            LocalConfigurations localConfigurations =
                configuration.Get<LocalConfigurations>();

            string apiBaseUrl = localConfigurations.ApiConfigurations.Url;
            this.httpClient.BaseAddress = new Uri(apiBaseUrl);

            return new RESTFulApiFactoryClient(this.httpClient);
        }
    }
}
