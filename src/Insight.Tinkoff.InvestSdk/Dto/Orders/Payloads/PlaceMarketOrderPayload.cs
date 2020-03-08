namespace Insight.Tinkoff.InvestSdk.Dto
{
    public sealed class PlaceMarketOrderPayload
    {
        public int Lots { get; set; }

        public OperationType Operation { get; set; }
    }
}