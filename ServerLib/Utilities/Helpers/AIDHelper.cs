using JsonLib;

namespace ServerLib.Utilities.Helpers
{
    public class AIDHelper
    {
        private static MongoID Id = MongoID.Default;
        public static string CreateNewID(string prefix = "")
        {
            if (Id == MongoID.Default)
            {
                Id = new MongoID(true).Next();
            }
            Id = Id.Next();
            var ret = Id.ToString();
            if (prefix != "")
            {
                ret = prefix + ret;
            }
            return ret;
        }

        public static int ToAID(string id)
        {
            var mongo = new MongoID(id);
            Console.WriteLine(mongo._timeStamp);
            Console.WriteLine(mongo._counter);
            var byts = BitConverter.GetBytes(mongo._counter);
            var cf = BitConverter.ToInt32(byts[0..4]);
            var cs = BitConverter.ToInt32(byts[4..8]);
            Console.WriteLine(cf);
            Console.WriteLine(cs);

            var newc = cf ^ cs;
            Console.WriteLine(newc);
            int timestap = Convert.ToInt32(mongo._timeStamp);
            if (timestap < 0)
            {
                timestap *= -1;
            }
            var ret_aid = timestap ^ newc;
            return ret_aid;
        }
    }
}
