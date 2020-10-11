using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonProject
{
    class ANeuron : INeuron<int, double>
    {
        const int threshold = 2;
        public double weight;
        int sum;

        public ANeuron(double weight)
        {
            this.weight = weight;
        }

        public double get()
        {
            if (sum >= threshold)
                return weight;
            else return -weight;
        }

        public void push(int value)
        {
            sum += value;
        }
    }
}
