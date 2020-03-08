namespace Insight.Tinkoff.InvestSdk.Dto
{
    public sealed class PlaceLimitOrderPayload
    {
        public int Lots { get; set; }

        public OperationType Operation { get; set; }

        public decimal Price { get; set; }
    }
}