namespace Insight.Tinkoff.InvestSdk.Dto.Payloads
{
    public sealed class PlaceMarketOrderPayload
    {
        public int Lots { get; set; }

        public OperationType Operation { get; set; }
    }
}