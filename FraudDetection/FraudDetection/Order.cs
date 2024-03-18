namespace FraudDetection
{
    public class Order
    {
        public int OrderId { get; set; }
        public int DealId { get; set; }
        public string? Email { get; set; }
        public string? NormalizedEmail { get; set; }
        public string? StreetAddress { get; set; }
        public string? NormalizedStreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? CreditCardNumber { get; set; }

        public Order()
        {                
        }

        public static Order ReadFromString(string orderData)
        {
            var order = new Order();
            var orderFields = orderData.Split(',');
            if (int.TryParse(orderFields[0], out var orderId))
            {
                order.OrderId = orderId;
            }
            if (int.TryParse(orderFields[1], out var dealId))
            {
                order.DealId = dealId;
            }
            order.Email = orderFields[2];
            order.NormalizedEmail = NormalizeEmail(order.Email);
            order.StreetAddress = orderFields[3];
            order.NormalizedStreetAddress = NormalizeStreetAddress(order.StreetAddress);
            order.City = orderFields[4];
            order.State = orderFields[5];
            order.ZipCode = orderFields[6];
            order.CreditCardNumber = orderFields[7];
            return order;
        }

        private static string NormalizeEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return email;
            }

            var parts = email.Split('@');
            if (parts.Length != 2)
            {
                // Not a valid email address
                return email;
            }

            var userName = parts[0].ToLowerInvariant();
            var domain = parts[1].ToLowerInvariant();

            // Ignore everything after '+'
            userName = userName.Split('+')[0];
            
            // Remove periods from local part
            userName = userName.Replace(".", "");

            return $"{userName}@{domain}";
        }

        private static string NormalizeStreetAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                return address;
            }
            var addressEquivalentWords = new List<(string word, string equivalentWord)>()
            {
                // TODO: Compleate this with more address equivalent words
                ("st.", "street"),
                ("rd.", "road"),
                (" il ", " illinois "),
                (" ny ", " new york "),
                (" ca ", " california "),
            };

            address = address.ToLowerInvariant();
            foreach (var equivalentWords in addressEquivalentWords)
            {
                address = address.Replace(equivalentWords.word, equivalentWords.equivalentWord);
            }

            return address;
        }
    }
}
