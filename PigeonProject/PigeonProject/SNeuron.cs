using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonProject
{
    class SNeuron : INeuron<Color, int>
    {
        Color color = new Color();

        void INeuron<Color, int>.clear()
        {
            color = Color.White;
        }

        int INeuron<Color, int>.get()
        {
            if (color.B <=225 || color.G <= 225 || color.R <= 225)
                return 1;
            else
                return 0;
        }

        void INeuron<Color, int>.push(Color value)
        {
            color = value;
        }
    }
}
