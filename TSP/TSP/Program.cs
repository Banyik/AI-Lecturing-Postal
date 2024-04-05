using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            State state = new State(10, 5);
            Solver nn = new NearestNeighbour(state);
            Console.ReadLine();
        }
    }
}
