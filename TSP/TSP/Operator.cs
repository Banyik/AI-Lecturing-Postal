using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    internal class Operator
    {
        City from, to;

        public Operator(City from, City to)
        {
            this.from = from;
            this.to = to;
        }

        internal City From { get => from; set => from = value; }
        internal City To { get => to; set => to = value; }

        public bool IsExistingState(State state)
        {
            if(from != to && state.Cities.Contains(to))
            {
                return true;
            }
            return false;
        }

        public State ApplyState(State state)
        {
            State newState = state;
            newState.Distance += GetDistance();
            newState.Cities.Remove(to);
            return newState;
        }
        public float GetDistance()
        {
            return Vector2.Distance(from.Position, to.Position);
        }
    }
}
