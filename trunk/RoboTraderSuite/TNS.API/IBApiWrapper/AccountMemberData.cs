using TNS.API.Infra.Bus;

namespace TNS.API.IBApiWrapper
{
    public class AccountMemberData : IMessage
    {
        public AccountMemberData(string account, string tag, string value, string currency)
        {
            Account = account;
            Values = value;
            Tag = tag;
            Currency = currency;
        }

        public string Account { get; set; }
        public string Values { get; set; }
        public string Currency { get; set; }
        public string Tag { get; set; }

        public override string ToString()
        {
            var toString =   
                $"Account={Account}, Values={Values}, Currency={Currency}, Tag={Tag}";
            return toString;
        }
    }
}
