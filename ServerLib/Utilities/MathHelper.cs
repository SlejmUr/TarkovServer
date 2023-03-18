namespace ServerLib.Utilities
{
    public class MathHelper
    {
        public static int ValuesBetween(int value, int minInput, int maxInput, int minOutput, int maxOutput)
        {
            return (maxOutput - minOutput) * ((value - minInput) / (maxInput - minInput)) + minOutput;
        }

        public static int GetRandomInt(int min = 0, int max = 100)
        {
            Random random = new();
            return random.Next(min, max);
        }

        public static int GetPrecentDifference(int num1, int num2)
        {
            return (num1 / num2) * 100;
        }

        public static int GetPrecentOf(int num1, int num2)
        {
            return (num1 / 100) * num2;
        }

        public static bool PrecentRandomBool(int percentage)
        {
            return GetRandomInt() < percentage;
        }

        public static string GetRandomArray(string[] array)
        {
            return array[GetRandomInt(0, array.Length)];
        }

        public static int Clamp(int value, int min, int max)
        {
            return Math.Min(Math.Max(value, min), max);
        }
    }
}
