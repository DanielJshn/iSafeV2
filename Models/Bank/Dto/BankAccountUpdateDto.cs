namespace apief
{
    public class BankAccountUpdateDto
    {
        public string? cardHolderName { get; set; }
        public string? cardNumber { get; set; }
        public string? expirationDateTimeStamp { get; set; }
        public string? cvv { get; set; }
        public string? pin { get; set; }
        public string? categoryId { get; set; }
    }
}