using System;
namespace Practice_12._1
{
    public enum Statuses
    {
        PowMustBeaPositiveOrZero,
        Success,
        ParametersAreEqual,
    }

    public static class Math
    {
        public static int Pow(int n1, int pow, out Statuses currStatus)
        {
            if(pow < 0)
            {
                currStatus = Statuses.PowMustBeaPositiveOrZero;
                return -1; 
            }
            int currInt = 1;
            for(int i = 0; i < pow; i++)
            {
                currInt *= n1;
            }
            currStatus = Statuses.Success;
            return currInt;
        }

        public static int Min(int a, int b, out Statuses currStatus)
        {
            if(a == b)
            {
                currStatus = Statuses.ParametersAreEqual;
                return -1;
            }

            currStatus = Statuses.Success;
            if (a > b)
            {
                return b;
            }
            return a;
        }

        public static int Max(int a, int b, out Statuses currStatus)
        {
            if (a == b)
            {
                currStatus = Statuses.ParametersAreEqual;
                return -1;
            }
            currStatus = Statuses.Success;
            if (a > b)
            {
                return a;
            }
            return b;
        }
    }
}

