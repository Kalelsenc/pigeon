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
        const int width = 9;
        const int height = 15;

        readonly List<INeuron<Color, int>> sensors;
        readonly List<INeuron<int, double>> associates;
        readonly INeuron<double, double> summator;

        Analizator(List<INeuron<Color, int>> sensors, List<INeuron<int, double>> associates, INeuron<double, double> summator)
        {
            this.sensors = sensors;
            this.associates = associates;
            this.summator = summator;
        }

        
        public static Analizator random()
        {
            List<INeuron<Color, int>> sensors = new List<INeuron<Color, int>>();
            List<INeuron<int, double>> associates = new List<INeuron<int, double>>();
            INeuron<double, double> summator = new RNeuron();

            Random random = new Random();

            /*
            for (int i = 0; i < width * height; i++)
                sensors.Add(new ....);
            */

            for (int i = 0; i < height; i++)
                associates.Add(new ANeuron(random.NextDouble()));
            
            return new Analizator(sensors, associates, summator);
        }

        public void clear()
        {
            foreach (INeuron<Color, int> sensor in sensors)
                sensor.clear();

            foreach (INeuron<Color, int> associate in associates)
                associate.clear();

            summator.clear();
        }

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
