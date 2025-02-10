namespace Demo.Classes
{
    internal static class intExtenstion
    {
        public static int Reverse(this int number)
        {
            int reversednumber = 0, reminder;
            while (number != 0)
            {
                reminder = number % 10;
                reversednumber = reversednumber * 10 + reminder;
                number = number / 10;
            }
            return reversednumber;
        }
    }
}
