using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    internal class TrialAndError : Solver
    {
        public TrialAndError(State state) : base(state)
        {
            Solve(state);
        }
        void Solve(State state)
        {
            Random rnd = new Random();
            Console.WriteLine(state.ToString());
            for (int i = 0; i < 1000; i++)
            {
                int operatorIndex = rnd.Next(0, Operators.Count);
                Operator currentOperator = Operators[operatorIndex];
                if (currentOperator.IsExistingState(state))
                {
                    state = currentOperator.ApplyState(state);
                    Console.WriteLine(state.ToString());
                    if (state.IsTargetReached())
                    {
                        Console.WriteLine($"Solution found at {i+1}!");
                        break;
                    }
                }
            }
            if (!state.IsTargetReached())
            {
                Console.WriteLine("Solver has failed!");
            }
        }
    }
}
