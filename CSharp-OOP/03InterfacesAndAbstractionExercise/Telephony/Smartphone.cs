using System;
using System.Linq;


namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string URL)
        {
            if (URL.Any(x => char.IsDigit(x)))
            {
                throw new InvalidOperationException("Invalid URL!");
            }
            return $"Browsing: {URL}!";
        }

        public string Call(string number)
        {
            Validator.ThrowIfNumberIsInvalid(number);

            return $"Calling... {number}" ;
        }
    }
}
