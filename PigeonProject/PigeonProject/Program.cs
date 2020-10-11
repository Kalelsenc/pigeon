using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PigeonProject
{
    class Program
    {
        static Analizator analizator;

        [STAThread]
        static void Main(string[] args)
        {
            SelectMenu();

        }
      
        static void SelectMenu()
        {
            OpenFileDialog OPF = new OpenFileDialog();
            Console.WriteLine("Меню:\n 1. Выбрать картинку\n 2. Выбрать папку\n 3. Обучится по картинке\n 4. Обучится по папке\n 5. Сохранить настройки\n 6. Загрузить настройки\n"+
                " 7. Задать случайные настройки\n 8. Напечатать веса ассоциативного слоя.");
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
                case 5:
                    {
                        OPF.ShowDialog();
                        saveConfig(analizator, OPF.FileName);
                        break;
                    }
                case 6:
                    {
                        OPF.ShowDialog();
                        analizator = loadConfig(OPF.FileName);

                        break;
                    }
                case 7:
                    {
                        analizator = Analizator.random();
                        Console.WriteLine("Заданы случайные настройки");
                        break;
                    }
                case 8:
                    {
                        Console.WriteLine(analizator.ToString());
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
            Bitmap pic = new Bitmap(path);

            if (pic == null)
                throw new Exception("File not found");

            analizator.push(pic);
            Console.WriteLine("result: " + analizator.get());
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

        static void saveConfig(Analizator analizator, string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
                formatter.Serialize(stream, analizator);
        }

        static Analizator loadConfig(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Analizator dataset;
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
                dataset = (Analizator)formatter.Deserialize(stream);

            return dataset;
        }
    }
}
