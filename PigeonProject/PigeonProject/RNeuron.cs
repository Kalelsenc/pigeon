using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonProject
{
    class RNeuron : INeuron<double, double>
    {
        double sum = 0;

        public void clear()
        {
            sum = 0;
        }

        public double get()
        {
            return sum;
        }

        public void push(double value)
        {
            sum += value;
        }
    }
}
