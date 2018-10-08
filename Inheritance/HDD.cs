using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class HDD : Storage
    {
        public int CountOfPart { get; set; }
        public int PartVolume { get; set; }

        public HDD() : base() { }

        public HDD(string name, string model, int speed, int countOfPart, int partVolume)
            :base(name, model)
        {
            Speed = speed;
            CountOfPart = countOfPart;
            PartVolume = partVolume;
            FreeMemoryVolume = countOfPart * partVolume;
        }

        public override int CopyToStorage(int countOfFile, int sizeOfFile)
        {
            int count = 0;

            for(int i = 0; i<CountOfPart; i++)
            {
                count += PartVolume * 1024 / sizeOfFile;

                if(count > countOfFile)
                {
                    FreeMemoryVolume -= countOfFile * sizeOfFile/1024;
                    return countOfFile;
                }
            }

            FreeMemoryVolume -= count * sizeOfFile/1024;

            return count;
        }

        public override double GetFreeMemoryVolume()
        {
            return FreeMemoryVolume;
        }

        public override double GetMemoryVolume()
        {
            return CountOfPart * PartVolume;
        }

        public override void ShowInfoAboutStorage()
        {
            Console.WriteLine("Наименование носителя: {0}", Name);
            Console.WriteLine("Модель: {0}", Model);
            Console.WriteLine("Количество разделов: {0}", CountOfPart);
            Console.WriteLine("Обьем разделов: {0}", PartVolume);
            Console.WriteLine("Свободный объем носителя: {0} ГБ", FreeMemoryVolume);
            Console.WriteLine("Скорость {0} МБайт/с", Speed);
        }
    }
}
