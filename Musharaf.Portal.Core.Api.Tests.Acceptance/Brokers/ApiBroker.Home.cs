namespace Musharaf.Portal.Core.Api.Tests.Acceptance.Brokers
{
    public partial class ApiBroker
    {
        private const string HomeRelativeUrl = "api/Home";

        public async ValueTask<string> GetHomeMessage() =>
            await this.apiFactoryClient.GetContentStringAsync(HomeRelativeUrl);
    }
}
