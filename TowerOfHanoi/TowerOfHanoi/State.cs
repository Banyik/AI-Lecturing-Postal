using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    internal class State : ICloneable
    {
        List<Pole> poles = new List<Pole>();
        int discCount;

        internal List<Pole> Poles { get => poles; set => poles = value; }
        public int DiscCount { get => discCount; set => discCount = value; }

        public State(List<Pole> pole, int discCount)
        {
            this.poles = pole;
            this.discCount = discCount;
        }

        public void SetStartingState(int poleCount)
        {
            for (int i = 0; i < poleCount; i++)
            {
                poles.Add(new Pole(new List<int>(), $"Pole {i}"));
            }
            for (int i = discCount; i > 0; i--)
            {
                poles[0].Discs.Add(i);
            }
        }

        public bool IsTargetReached()
        {
            return poles[poles.Count - 1].Discs.Count == discCount;
        }

        public override string ToString()
        {
            string value = "";
            foreach (var pole in poles)
            {
                string discs = "";
                if(pole.Discs.Count > 0)
                {
                    foreach (var disc in pole.Discs)
                    {
                        discs += $"{disc}, ";
                    }
                    discs = discs.TrimEnd(',', ' ');
                }
                else
                {
                    discs = "None";
                }
                value += $"{pole.Name}; Discs: {discs}\n";
            }
            value += "--------------------";
            return value;
        }

        public object Clone()
        {
            State newState = new State(new List<Pole>(), discCount);
            for (int i = 0; i < poles.Count; i++)
            {
                newState.poles.Add((Pole)poles[i].Clone());
            }
            return newState;
        }

        public override bool Equals(object obj)
        {
            if(!(obj is State))
            {
                return false;
            }
            State other = obj as State;
            if(other.discCount != this.discCount)
            {
                return false;
            }
            for (int i = 0; i < this.poles.Count; i++)
            {
                if (poles[i].Discs.SequenceEqual(other.poles[i].Discs) == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
