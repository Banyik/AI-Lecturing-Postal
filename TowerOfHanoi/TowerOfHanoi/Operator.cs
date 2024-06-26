﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    internal class Operator
    {
        int from, to;

        public Operator(int from, int to)
        {
            this.from = from;
            this.to = to;
        }

        public bool IsExistingState(State state)
        {
            if (state.Poles[to].Discs.Count > 0)
            {
                return state.Poles[from].Discs.Count > 0 &&
                    state.Poles[to].Discs[state.Poles[to].Discs.Count - 1] >
                    state.Poles[from].Discs[state.Poles[from].Discs.Count - 1];
            }
            return state.Poles[from].Discs.Count > 0;
        }

        public State ApplyState(State state)
        {
            State newState = (State)state.Clone();
            newState.Poles[to].Discs.Add(state.Poles[from].Discs[state.Poles[from].Discs.Count - 1]);
            newState.Poles[from].Discs.RemoveAt(state.Poles[from].Discs.Count - 1);
            return newState;
        }
    }
}
