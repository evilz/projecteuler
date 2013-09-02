using System.Collections.Generic;
using System.Linq;

namespace Projecteuler
{
    public class Problem3 : IProblem
    {

        #region IProblem implementation

        public long Resolve()
        {
            long max = 600851475143;
            return PrimeNumbers(max).Max();
        }

        public int Ref
        {
            get
            {
                return 3;
            }
        }

        public string Description
        {
            get
            {
                return "The prime factors of 13195 are 5, 7, 13 and 29.\nWhat is the largest prime factor of the number 600851475143 ?";
            }
        }

        #endregion

        public static IEnumerable<long> PrimeNumbers(long source)
        {
            while (source > 1)
            {
                var divider = (
                    from i in LongRange(2, source)
                    where (source % i == 0) || (source == i)
                    select i).First();
                yield return divider;
                source = source / divider;
            }
        }

        public static IEnumerable<long> LongRange(long start, long end)
        {
            for (long l = start; l <= end; l++)
                yield return l;
        }
    }
}