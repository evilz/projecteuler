namespace projecteuler
{
    public class problem3
    {
        //The prime factors of 13195 are 5, 7, 13 and 29.
        //What is the largest prime factor of the number 600851475143 ?
        public static long GetLargetPrimeFactor()
        {
            long max = 600851475143;

            var root = FindPrimes(max);

            PrimeTreeNone current = root;
            while (current.Right != null)
                current = current.Right;

            return current.Prime;
        }

        public static PrimeTreeNone FindPrimes(long number)
        {
            PrimeTreeNone node = new PrimeTreeNone(number);
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    node.Left = FindPrimes(i);
                    node.Right = FindPrimes(number / i);
                    return node;
                }
            }
            return node;
        }
    }

    public class PrimeTreeNone
    {
        public PrimeTreeNone(long number)
        {
            Prime = number;
        }

        public long Prime;
        public PrimeTreeNone Left;
        public PrimeTreeNone Right;
    }
}