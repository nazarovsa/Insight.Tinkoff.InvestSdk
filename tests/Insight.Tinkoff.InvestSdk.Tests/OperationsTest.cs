using System;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.InvestSdk.Dto;
using Insight.Tinkoff.InvestSdk.Infrastructure;
using Insight.Tinkoff.InvestSdk.Services;
using Insight.Tinkoff.InvestSdk.Tests.Base;
using Xunit;

namespace Insight.Tinkoff.InvestSdk.Tests
{
    public sealed class OperationsTest : TestBase
    {
        private readonly IOperationService _operationService;

        public OperationsTest()
        {
            _operationService = new OperationService(RestConfiguration);
        }

        [Fact]
        public async Task Should_get_operations()
        {
            var filter = new OperationsFilter
            {
                From = DateTime.Now - TimeSpan.FromDays(30),
                To = DateTime.Now,
                // Accenture
                Figi = "BBG000D9D830",
                Interval = OperationInterval.Month
            };

            var response = await _operationService.Get(filter, CancellationToken.None);

            ValidateRestResponse(response);
            Assert.NotNull(response.Operations);
        }
    }
}