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
        public static Bitmap bmp;
        [STAThread]
        static void Main(string[] args)
        {
            SelectMenu();
        }

        static void SelectMenu()
        {
            FolderBrowserDialog FBW = new FolderBrowserDialog();
            OpenFileDialog OFD = new OpenFileDialog();
            Console.WriteLine("Меню:\n 1. Выбрать картинку\n 2. Выбрать папку\n 3. Обучится по картинке\n 4. Обучится по папке\n 5. Сохранить настройки\n 6. Загрузить настройки\n"+
                " 7. Задать случайные настройки\n 8. Напечатать веса ассоциативного слоя.\n 9. Нарисовать картинку самому\n 10. Переключить режим отладки.");

            int selection = Convert.ToInt16(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    {
                        OFD.ShowDialog();
                        uploadImage(OFD.FileName);
                        break;
                    }
                case 2:
                    {

                        FBW.ShowDialog();
                        uploadFolder(FBW.SelectedPath);
                        break;
                    }
                case 3:
                    {
                        OFD.ShowDialog();
                        LearnByImage(OFD.FileName);
                        break;
                    }
                case 4:
                    {
                        FBW.ShowDialog();
                        LearnByFolder(FBW.SelectedPath);
                        break;
                    }
                case 5:
                    {
                        OFD.ShowDialog();
                        saveConfig(analizator, OFD.FileName);
                        break;
                    }
                case 6:
                    {
                        OFD.ShowDialog();
                        analizator = loadConfig(OFD.FileName);

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
                case 9:
                    {


                        letterPaint();
                        uploadImage(bmp);
                        break;
                    }

                    case 10:
                        {

                            Console.WriteLine("Debug mode: "+analizator.shiftDebugMode());


                            break;
                        }
                default:
                    Console.WriteLine("Вы написали фигню, попробуйте заново");
                    break;

            }
            SelectMenu();
        }

        static void uploadImage(string path)
        {

            Bitmap pic = new Bitmap(Image.FromFile(path), 30, 30);

            DirectoryInfo dir = new DirectoryInfo(path);
            pic.Tag = dir.Name;


            if (pic == null)
                throw new Exception("File not found");

            analizator.setLearn(false);

            analizator.push(pic);
            Console.WriteLine("value: "+pic.Tag + " result: " + analizator.get());

        }

        static void uploadImage(Bitmap path)
        {

            analizator.setLearn(false);

            analizator.push(path);
            Console.WriteLine("result: " + analizator.get());

        }

        static void uploadFolder(string path)
        {

            DirectoryInfo dir = new DirectoryInfo(path);
            List<Bitmap> uploadImages = new List<Bitmap>();
            FileInfo[] fileInfo = dir.GetFiles();

            for (int i=0;i<Convert.ToInt16(dir.GetFiles().Length.ToString());i++)
            {
                Bitmap pic = new Bitmap(new Bitmap(fileInfo[i].FullName), 30, 30);
                pic.Tag = fileInfo[i].Name;
                uploadImages.Add(pic);
            }

            if (uploadImages.Capacity == 0)
                throw new Exception("Folder is empty");

            analizator.setLearn(false);

            foreach (Bitmap bitmap in uploadImages)
            {
                analizator.push(bitmap);
                string result = analizator.get();
                Console.WriteLine("value: "+bitmap.Tag+" result:" + result + (result == bitmap.Tag.ToString().Split('_')[0] ?" - ok" : " - not ok"  ));
            }

        }

        static void LearnByImage(string path)
        {
            Bitmap pic = new Bitmap(new Bitmap(path), 30, 30);
            DirectoryInfo dir = new DirectoryInfo(path);
            pic.Tag = dir.Name;

            if (pic == null)
                throw new Exception("File not found");

            analizator.setLearn(true);

            analizator.push(pic);
            Console.WriteLine("value: " + pic.Tag + " result: " + analizator.get());
        }

        static void LearnByFolder(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            List<Bitmap> uploadImages = new List<Bitmap>();
            FileInfo[] fileInfo = dir.GetFiles();

            for (int i = 0; i < Convert.ToInt16(dir.GetFiles().Length.ToString()); i++)
            {
                Bitmap pic = new Bitmap(new Bitmap(fileInfo[i].FullName), 30, 30);
                pic.Tag = fileInfo[i].Name;
                uploadImages.Add(pic);
            }

            if (uploadImages.Capacity == 0)
                throw new Exception("Folder is empty");

            analizator.setLearn(true);

            for(int i = 0; i < 100; i++)
            {
                foreach (Bitmap bitmap in uploadImages)
                {
                    analizator.push(bitmap);
                    analizator.get();
                }
                Console.WriteLine(i);

            }
         
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
            dataset.randomSensorsAndSummator();
            return dataset;
        }

        static void getFileName(string path)
        {

        }

        static void letterPaint()
        {
            Paint paint = new Paint();
            paint.ShowDialog();
        }
    }
}
