using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int fileSize = 780;
            int countOfFile = 565 * 1024 / 780;

            while (true)
            {
                Storage[] arrStorage =
                {
                   new Flash("Flash", "Kingstone", 600, 32),
                   new DVD("DVD", "Creative PC-DVD 5x", 6.6, "односторонний"),
                   new HDD("HDD", "Seagate Laptop Thin HDD ST500LM021", 135, 2, 250)
                };

                Console.WriteLine("Количество файлов: {0}, Размер одного файла: {1}",countOfFile, fileSize );
                Console.WriteLine("1 - Общее количество памяти всех устройств");
                Console.WriteLine("2 - Копирование информации на устройство");
                Console.WriteLine("3 - Время необходимое для копирования");
                Console.WriteLine("4 - Необходимые носители для переноса информации");

                string strKey = Console.ReadLine();
                int key;
                int.TryParse(strKey, out key);

                switch (key)
                {
                    case 1:
                        Console.WriteLine("{0} Гб.", GetTotalMemory(arrStorage));
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Количество не скопированных файлов: {0}",CopyToStorage(arrStorage, countOfFile, fileSize));
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("Время необходимое для копирования: {0} мин.", GetTimeToCopy(arrStorage, countOfFile, fileSize));
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.WriteLine("Необходимые накопители для переноса информаций: ");
                        InfoAboutStorageToCopy(arrStorage, countOfFile, fileSize);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        static double GetTotalMemory(Storage [] arrStorage)
        {
            double totalMemory = 0;

            for(int i = 0; i<arrStorage.Length; i++)
            {
                totalMemory+=arrStorage[i].GetMemoryVolume();
            }

            return totalMemory;
        }

        static double CopyToStorage(Storage[]arrStorage, int countOfFile, int sizeOfFile)
        {
            int reminder = countOfFile; //остаток файлов

            for (int i = 0; i<arrStorage.Length; i++)
            {
                reminder -= arrStorage[i].CopyToStorage(reminder, sizeOfFile);
                if (reminder == 0) return 0;
            }
           
            return reminder;
        }

        static double GetTimeToCopy(Storage[] arrStorage, int countOfFile, int sizeOfFile)
        {
            int reminder = countOfFile;
            double sec = 0;

            for (int i = 0; i < arrStorage.Length; i++)
            {
                reminder -= arrStorage[i].CopyToStorage(reminder, sizeOfFile);
                sec += ((arrStorage[i].GetMemoryVolume() *1024) - (arrStorage[i].GetFreeMemoryVolume()*1024)) / arrStorage[i].Speed;
                if (reminder == 0) break;
            }
            return sec/60;
        }

        //Необходимое количество накопителей для переноса информаций
        static void InfoAboutStorageToCopy(Storage[] arrStorage, int countOfFile, int sizeOfFile)
        {
            int reminder = countOfFile; //остаток файлов

            for (int i = 0; reminder>0; i++)
            {
                Console.WriteLine(arrStorage[i].Name);
                reminder -= arrStorage[i].CopyToStorage(reminder, sizeOfFile);
                if (i == arrStorage.Length - 1) i = -1;
            }
        }
    }
}
