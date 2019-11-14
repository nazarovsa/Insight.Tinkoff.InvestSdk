using System;
using System.Threading;
using System.Threading.Tasks;
using Insight.Tinkoff.Invest.Domain;
using Insight.Tinkoff.Invest.Dto;
using Insight.Tinkoff.Invest.Infrastructure;
using Insight.Tinkoff.Invest.Services;
using Insight.Tinkoff.Invest.Tests.Base;
using Xunit;

namespace Insight.Tinkoff.Invest.Tests
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