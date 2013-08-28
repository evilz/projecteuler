using System.Linq;

namespace Projecteuler
{
    public class Problem1 : IProblem
    {
        public long Resolve()
        {
            return Enumerable.Range(0, 1000)
                    .Where(i => i % 3 == 0 || i % 5 == 0)
                    .Sum();
        }

        public int Ref { get { return 1; } }

        public string Description
        {
            get
            {
                return "If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.\n Find the sum of all the multiples of 3 or 5 below 1000.";
            }
        }
    }
}
