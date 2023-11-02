﻿using EFT;

namespace ServerLib.Utilities.Helpers
{
    public class AIDHelper
    {
        public static string CreateNewID(string prefix = "")
        {
            MongoID mongo = new(true);
            var ret = mongo.Next().ToString();
            if (prefix != "")
            {
                ret = prefix + ret;
            }
            return ret;
        }

        public static int ToAID(string id)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(id);
            int i_aid = 0;
            for (int i = 0; i < bytes.Length; i += 4)
            {

                i_aid += BitConverter.ToInt32(bytes[i..(i + 4)]);
            }

            return i_aid;
        }
    }
}