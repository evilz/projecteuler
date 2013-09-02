using System;
using System.Linq;
using System.Collections.Generic;

namespace Projecteuler
{
    public class Problem4 : IProblem
    {

        #region IProblem implementation

        public long Resolve()
        {
            // not so smart :( , can be faster
            return Enumerable.Range(100, 900)
                    .SelectMany((i,index) => Enumerable.Range(100, 900).Select(j => j * i))
                    .Where(i => i.ToString() == string.Join(string.Empty, i.ToString().Reverse()))
                    .Max();
        }

        public int Ref
        {
            get
            {
                return 4;
            }
        }

        public string Description
        {
            get
            {
                return "A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.\n\nFind the largest palindrome made from the product of two 3-digit numbers.";
            }
        }

        #endregion

    }
}

