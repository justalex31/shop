namespace Web.Helper
{
    public class MathFunc
    {
        public static double Aver(int[] r)
        {
            int sum = 0;
            foreach (var item in r)
                sum += item;

            return sum == 0 ? sum : sum / r.Length;
        }
    }
}
