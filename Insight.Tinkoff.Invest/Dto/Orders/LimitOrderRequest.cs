namespace Insight.Tinkoff.Invest.Dto
{
    public sealed class LimitOrderRequest
    {
        public int Lots { get; set; }

        public OperationType Operation { get; set; }

        public decimal Price { get; set; }
    }
}