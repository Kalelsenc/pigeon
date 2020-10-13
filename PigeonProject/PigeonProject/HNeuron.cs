using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonProject
{
    class HNeuron : INeuron<double, double>
    {
        double sum = 0;

        public void clear()
        {
            sum = 0;
        }

        public double get()
        {
            throw new NotImplementedException();
        }

        public void push(double value)
        {
            sum = sum + value;
        }
    }
}
