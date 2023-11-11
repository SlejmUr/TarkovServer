namespace JsonLib.Classes.Response
{
    public class GetItemPrices
    {
        public int supplyNextTime { get; set; }
        public Dictionary<string, int> prices { get; set; }
        public Dictionary<string, int> currencyCourses { get; set; }
    }
}
