using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Services;
using Insight.Tinkoff.InvestSdk.Tests.Base;
using Xunit;

namespace Insight.Tinkoff.InvestSdk.Tests
{
    public sealed class UserTest : TestBase
    {
        private readonly IUserService _userService;

        public UserTest()
        {
            _userService = new UserService(RestConfiguration);
        }

        [Fact]
        public async Task Should_get_accounts()
        {
            var response = await _userService.GetAccounts();

            ValidateRestResponse(response);
            Assert.NotEmpty(response.Accounts);
        }
    }
}