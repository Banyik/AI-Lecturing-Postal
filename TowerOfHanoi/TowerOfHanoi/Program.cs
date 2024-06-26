﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            State state = new State(new List<Pole>(), 3);
            state.SetStartingState(3);
            Solver solver = new BranchAndBound(state);
            Console.ReadLine();
        }
    }
}
