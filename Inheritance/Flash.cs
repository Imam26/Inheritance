using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Flash:Storage
    {
        public int MemoryVolume { get; set; }

        public Flash() : base() { }

        public Flash(string name, string model, int speed, int memoryVolume)
            :base(name, model)
        {
            Speed = speed;
            FreeMemoryVolume = MemoryVolume = memoryVolume;
        }

        public override double GetMemoryVolume()
        {
            return MemoryVolume;
        }

        public override int CopyToStorage(int countOfFile, int sizeOfFile)
        {
            int count = (int)(FreeMemoryVolume*1024 / sizeOfFile);

            if (count > countOfFile)
            {
                FreeMemoryVolume -= countOfFile * sizeOfFile/1024;
                return countOfFile;
            }

            FreeMemoryVolume = 0;

            return count;
        }

        public override double GetFreeMemoryVolume()
        {
            return FreeMemoryVolume;
        }

        public override void ShowInfoAboutStorage()
        {
            Console.WriteLine("Наименование носителя: {0}", Name);
            Console.WriteLine("Модель: {0}", Model);
            Console.WriteLine("Объем носителя: {0} Гб", MemoryVolume);
            Console.WriteLine("Свободный объем носителя: {0} Гб", FreeMemoryVolume);
            Console.WriteLine("Скорость: {0} Мбайт/с", Speed);
        }
    }
}
