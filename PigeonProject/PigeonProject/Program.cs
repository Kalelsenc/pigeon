using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PigeonProject
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            SelectMenu();
        }

        
        static void SelectMenu()
        {
            OpenFileDialog OPF = new OpenFileDialog();
            Console.WriteLine("Меню:\n 1. Выбрать картинку\n 2. Выбрать папку\n 3. Обучится по картинке\n 4. Обучится по папке");
            int selection = Convert.ToInt16(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    {
                        OPF.ShowDialog();
                        SelectImage(OPF.FileName);
                        break;
                    }
                case 2:
                    {
                        OPF.ShowDialog();
                        SelectFolder(OPF.FileName);
                        break;
                    }
                case 3:
                    {
                        OPF.ShowDialog();
                        LearnByImage(OPF.FileName);
                        break;
                    }
                case 4:
                    {
                        OPF.ShowDialog();
                        LearnByFolder(OPF.FileName);
                        break;
                    }
                default:
                    Console.WriteLine("Вы написали фигню");
                    break;

            }
            SelectMenu();
        }

        static void SelectImage(string path)
        {
            Console.WriteLine(path);
        }

        static void SelectFolder(string path)
        {
            Console.WriteLine(path);
        }

        static void LearnByImage(string path)
        {
            Console.WriteLine(path);
        }

        static void LearnByFolder(string path)
        {
            Console.WriteLine(path);
        }
    }
}
