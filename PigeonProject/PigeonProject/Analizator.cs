using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonProject
{
    class Analizator : INeuron<Bitmap, string>
    {
        readonly List<INeuron<Color, int>> sensors;
        readonly List<INeuron<int, double>> associate;
        readonly INeuron<double, double> summator;

        Analizator(List<INeuron<Color, int>> sensors, List<INeuron<int, double>> associate, INeuron<double, double> summator)
        {
            this.sensors = sensors;
            this.associate = associate;
            this.summator = summator;
        }

        /*
        public static Analizator random()
        {

        }
        */
        public string get()
        {
            throw new NotImplementedException();
        }

        public void push(Bitmap value)
        {
            throw new NotImplementedException();
        }
    }
}
