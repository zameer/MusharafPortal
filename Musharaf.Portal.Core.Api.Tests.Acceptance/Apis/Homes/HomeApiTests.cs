using FluentAssertions;
using Musharaf.Portal.Core.Api.Tests.Acceptance.Brokers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musharaf.Portal.Core.Api.Tests.Acceptance.Apis.Homes
{
    [Collection(nameof(ApiTestCollection))]
    public class HomeApiTests
    {
        private readonly ApiBroker apiBroker;
        public HomeApiTests(ApiBroker apiBroker) =>
            this.apiBroker = apiBroker;

        [Fact]
        public async Task ShouldReturnHomeMessageAsync()
        {
            // given
            string expectedMessage = "Hi Zam";

            // when
            string actualMessage =
                await this.apiBroker.GetHomeMessage();

            // then
            actualMessage.Should().BeEquivalentTo(expectedMessage);
        }
    }
}
