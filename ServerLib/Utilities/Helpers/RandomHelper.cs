namespace ServerLib.Utilities.Helpers
{
    public class RandomHelper
    {
        public static T GetArrayValue<T>(IList<T> arr) where T : class
        {
            return arr[GetRandomInt(0, arr.Count - 1)];
        }

        public static int GetRandomInt(int min = 0, int max = 100)
        {
            Random random = new();
            return random.Next(min, max);
        }

        public static int GetRandomDoubleInt(double min = 0, double max = 100)
        {
            int imin = (int)min;
            int imax = (int)max;
            return GetRandomInt(imin, imax);
        }
    }
}
