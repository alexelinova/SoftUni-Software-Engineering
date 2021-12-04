namespace VaporStore.Common
{
    public static class GlobalConstants
    {
        //User
        public const int UsernameMaxLength = 20;
        public const int UsernameMinLength = 3;
        public const string UserFullNameRegex = @"^[A-Z][a-z]{2,} [A-Z][a-z]{2,}";
        public const int UserMinAgeValue = 3;
        public const int UserMaxAgeValue = 103;

        //Card
        public const string CardNumberRegex = @"[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}";
        public const string CardCVCRegex = @"[0-9]{3}";

        //Purchase
        public const string PurchaseKeyRegex = @"[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}";
    }
}
