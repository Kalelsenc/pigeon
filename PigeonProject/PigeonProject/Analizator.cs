using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonProject
{
    [Serializable]
    class Analizator : INeuron<Bitmap, string>
    {
        const int width = 9;
        const int height = 15;
        const double learnStepUp = 0.001;
        const double learnStepDown = -0.0013;
        bool learn = false;
        bool debug = false;
        string name;

        readonly List<SNeuron> sensors;
        readonly List<ANeuron> associates;
        readonly RNeuron summator;

        Analizator(List<SNeuron> sensors, List<ANeuron> associates,RNeuron summator)
        {
            this.sensors = sensors;
            this.associates = associates;
            this.summator = summator;
        }

        
        public static Analizator random()
        {
            List<SNeuron> sensors = new List<SNeuron>();
            List<ANeuron> associates = new List<ANeuron>();
            RNeuron summator = new RNeuron();

            Random random = new Random();

            for (int i = 0; i < width * height; i++)
                sensors.Add(new SNeuron());
            

            for (int i = 0; i < width * height; i++)
                associates.Add(new ANeuron(random.NextDouble()));
            
            return new Analizator(sensors, associates, summator);
        }

        public void clear()
        {

            foreach (SNeuron sensor in sensors)
                sensor.clear();

            foreach (ANeuron associate in associates)
                associate.clear();

            summator.clear();
            name = "";
        }

        public string get()
        {

            for (int i = 0; i < sensors.Count; i++)
                associates[i].push(sensors[i].get());

            foreach (ANeuron neuron in associates)
                summator.push(neuron.get());

            double doubleCode = summator.get();
            int code = (int)Math.Round(doubleCode, MidpointRounding.ToEven);
           
            string result = getLetterByCode(code);

            if (learn)
            {
                string rightLetter = name.Split('_')[0];
                if (result != rightLetter)
                {
                    if (code < getCodeByLetter(rightLetter))
                        associates.ForEach(x => x.learn(learnStepUp));
                    else associates.ForEach(x => x.learn(learnStepDown));
                }
            }
            else
            {
                Console.WriteLine(doubleCode);
                Console.WriteLine(code);
            }
            clear();
            return result;
        }

        public int getCodeByLetter(string letter)
        {
            switch (letter)
            {
                case "a":
                    return 1;
                case "б":
                    return 2;
                case "в":
                    return 3;
                case "г":
                    return 4;
                case "д":
                    return 5;
                case "е":
                    return 6;
                case "ё":
                    return 7;
                case "ж":
                    return 8;
                case "з":
                    return 9;
                case "и":
                    return 10;
                case "й":
                    return 11;
                case "к":
                    return 12;
                case "л":
                    return 13;
                case "м":
                    return 14;
                case "н":
                    return 15;
                case "о":
                    return 16;
                case "п":
                    return 17;
                case "р":
                    return 18;
                case "с":
                    return 19;
                case "т":
                    return 20;
                case "у":
                    return 21;
                case "ф":
                    return 22;
                case "х":
                    return 23;
                case "ц":
                    return 24;
                case "ч":
                    return 25;
                case "ш":
                    return 26;
                case "щ":
                    return 27;
                case "ъ":
                    return 28;
                case "ы":
                    return 29;
                case "ь":
                    return 30;
                case "э":
                    return 31;
                case "ю":
                    return 32;
                case "я":
                    return 33;
                default: throw new Exception ("Ежжи, такой буквы я не знаю, пашел к чорту.");

            }
        }

        public string getLetterByCode(int code)
        {
            switch (code)
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
                    sensors[x * y + x].push(value.GetPixel(x, y));
            name = (string)value.Tag;
        }

        public void setLearn(bool flag)
        {
            learn = flag;
        }

        public bool shiftDebugMode()
        {
            debug = !debug;
            return debug;
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
