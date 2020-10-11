using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonProject
{
    [Serializable]
    class ANeuron : INeuron<int, double>
    {
        const int threshold = 1;
        public double weight;
        int sum=0;

        public ANeuron(double weight)
        {
            this.weight = weight;
        }

        public void clear()
        {
            sum = 0;
        }

        public double get()
        {
             return weight*(double)sum;
        }

        public void learn(double value)
        {
             weight *= sum;
        }

        public void push(int value)
        {
            sum += value;
        }
    }
}
