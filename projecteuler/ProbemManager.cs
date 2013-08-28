using System;
using System.Collections.Generic;
using System.Linq;

namespace Projecteuler
{
    public class ProbemManager
    {
        private Dictionary<int,IProblem> _problems;

        public ProbemManager()
        {
            _problems = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => typeof(IProblem).IsAssignableFrom(t) && t.IsClass)
                .Select(t => Activator.CreateInstance(t) as IProblem)
                .ToDictionary(p => p.Ref, p => p);
        }

        public void Start()
        {

            // not best way ....
            int count = _problems.Count();

            int problemRef;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to ProjectEuler Problems :)\n Choose a problem number between 1 and " + count);
                Console.WriteLine("Or enter 0 to quit");

                var input = Console.ReadLine();
                if (int.TryParse(input, out problemRef))
                {
                    if (problemRef == 0)
                        break;
                    if (problemRef > 0 && problemRef <= count)
                    {
                        DisplayProblem(problemRef);
                    }
                }
            }
        }

        void DisplayProblem(int problemRef)
        {
            var problem = _problems[problemRef];

            Console.WriteLine(problem.Description);
            Console.WriteLine(string.Join(string.Empty, Enumerable.Repeat("=", 80)));
            Console.WriteLine("Anwser : " + problem.Resolve());
            Console.WriteLine("\n Press any Key to continue");
            Console.ReadKey();
        }
    }
}

