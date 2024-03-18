namespace FraudDetection
{
    public class FraudDetector
    {
        private int _totalOrders;
        private List<Order> _orders = new List<Order>();

        public FraudDetector()
        {
        }

        public void LoadData(List<string> inputData)
        {
            if (inputData.Any())
            {
                // TryParse the total orders
                if (int.TryParse(inputData.First(), out _totalOrders))
                {
                    _orders.Clear();
                    for (int i = 1; i < inputData.Count; i++)
                    {
                        var order = Order.ReadFromString(inputData[i]);
                        _orders.Add(order);
                    }
                }
            }
        }

        public List<int> GetFraudulentOrdersIds()
        {
            // We use HashSet instead of List in fraudulentOrderIds to not include a order id more than one time.
            var fraudulentOrderIds = new HashSet<int>();
            var emailDealCheckedOrders = new List<(int orderId, string normalizedEmail, int dealId, string creaditCard)>();
            var addressDealCheckedOrders = new List<(int orderId, int dealId, string? normalizedStreetAddress, string? city, string? state, string? zipCode, string? creaditCard)>();

            foreach (var order in _orders)
            {
                // Fraud cases number 1
                // Two orders have the same email and deal id, but different credit card information, regardless of street address.
                var orderSameEmailDealId = emailDealCheckedOrders.FirstOrDefault(o =>
                    o.normalizedEmail == order.NormalizedEmail &&
                    o.dealId == order.DealId);
                if (orderSameEmailDealId != default && orderSameEmailDealId.creaditCard != order.CreditCardNumber)
                {
                    // The current order is fraudulent and also the orderSameEmailDealId
                    
                    fraudulentOrderIds.Add(order.OrderId);
                    fraudulentOrderIds.Add(orderSameEmailDealId.orderId);
                }
                else
                {
                    emailDealCheckedOrders.Add((order.OrderId, order.NormalizedEmail, order.DealId, order.CreditCardNumber));
                }

                // Fraud cases number 2
                // Two orders have the same Address/City/State/Zip and deal id, but different credit card information, regardless of email address.
                var orderSameAddressCityStateZipDealId = addressDealCheckedOrders.FirstOrDefault(o =>
                    o.normalizedStreetAddress == order.NormalizedStreetAddress &&
                    o.city == order.City && 
                    o.state == order.State &&
                    o.zipCode == order.ZipCode &&
                    o.dealId == order.DealId);
                if (orderSameAddressCityStateZipDealId != default && orderSameAddressCityStateZipDealId.creaditCard != order.CreditCardNumber)
                {
                    // The current order is fraudulent and also the orderSameAddressCityStateZipDealId
                    fraudulentOrderIds.Add(order.OrderId);
                    fraudulentOrderIds.Add(orderSameAddressCityStateZipDealId.orderId);
                }
                else
                {
                    addressDealCheckedOrders.Add((order.OrderId, order.DealId, order.NormalizedStreetAddress, order.City, order.State, order.ZipCode, order.CreditCardNumber ));
                }
            }

            // return the list order bt ascunding by ID.
            return fraudulentOrderIds.OrderBy(id => id).ToList();
        }
    }
}
