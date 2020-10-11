using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

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
            FolderBrowserDialog FBW = new FolderBrowserDialog();
            OpenFileDialog OFD = new OpenFileDialog();
            Console.WriteLine("Меню:\n 1. Выбрать картинку\n 2. Выбрать папку\n 3. Обучится по картинке\n 4. Обучится по папке");
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
                default:
                    Console.WriteLine("Вы написали фигню, попробуйте заново");
                    break;

            }
            SelectMenu();
        }

        static void uploadImage(string path)
        {
            Image uImage = Image.FromFile(path);
        }

        static void uploadFolder(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            List<Image> uploadImages = new List<Image>();
            FileInfo[] fileInfo = dir.GetFiles();
            for (int i=0;i<Convert.ToInt16(dir.GetFiles().Length.ToString());i++)
            {
                uploadImages.Add(Image.FromFile(fileInfo[i].FullName));
            }
            
        }

        static void LearnByImage(string path)
        {
            Image lImage = Image.FromFile(path);
        }

        static void LearnByFolder(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            List<Image> learnImages = new List<Image>();
            FileInfo[] fileInfo = dir.GetFiles();
            for (int i = 0; i < Convert.ToInt16(dir.GetFiles().Length.ToString()); i++)
            {
                learnImages.Add(Image.FromFile(fileInfo[i].FullName));
            }
        }
    }
}
