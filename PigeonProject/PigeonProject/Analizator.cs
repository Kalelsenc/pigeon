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

        bool learn = false;

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

            learn = false;
        }

        public string get()
        {

            for (int i = 0; i < sensors.Count; i++)
                associates[i / width].push(sensors[i].get());

            foreach (ANeuron neuron in associates)
                summator.push(neuron.get());

            double doubleCode = summator.get();
            int code = (int)Math.Round(doubleCode);
            switch(code)
            {
                case 1:
                    return "a";
                case 2:
                    return "б";
                case 3:
                    return "в";
                case 4:
                    return "г";
                case 5:
                    return "д";
                case 6:
                    return "е";
                case 7:
                    return "ё";
                case 8:
                    return "ж";
                case 9:
                    return "з";
                case 10:
                    return "и";
                case 11:
                    return "й";
                case 12:
                    return "к";
                case 13:
                    return "л";
                case 14:
                    return "м";
                case 15:
                    return "н";
                case 16:
                    return "о";
                case 17:
                    return "п";
                case 18:
                    return "р";
                case 19:
                    return "с";
                case 20:
                    return "т";
                case 21:
                    return "у";
                case 22:
                    return "ф";
                case 23:
                    return "х";
                case 24:
                    return "ц";
                case 25:
                    return "ч";
                case 26:
                    return "ш";
                case 27:
                    return "щ";
                case 28:
                    return "ъ";
                case 29:
                    return "ы";
                case 30:
                    return "ь";
                case 31:
                    return "э";
                case 32:
                    return "ю";
                case 33:
                    return "я";
                default: return "Ежжи, такой буквы я не знаю, пашел к чорту.";

            }
        }

        public void push(Bitmap value)
        {
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    sensors[y * height + x].push(value.GetPixel(x, y));
        }

        public void setLearn(bool flag)
        {
            learn = flag;
        }

        public override string ToString()
        {
            string result = "";

            foreach (ANeuron neuron in associates)
                result += neuron.weight + " ";

            return result;
        }
    }
}
