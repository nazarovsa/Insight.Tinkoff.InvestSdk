namespace Insight.Tinkoff.Invest.Dto.Orders
{
    public sealed class LimitOrderRequest
    {
        public int Lots { get; set; }

        public OperationType Operation { get; set; }

        public decimal Price { get; set; }
    }
}