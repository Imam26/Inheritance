using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class DVD : Storage
    {
        public string Type { get; set; }
        private double MemoryVolume { get; set; }

        public DVD() : base() { }

        public DVD(string name, string model, double speed, string type)
            :base(name, model)
        {
            Speed = speed;
            Type = type;
            FreeMemoryVolume = MemoryVolume = (type == "односторонний") ? 4.7 : 9;
        }

        public DVD(string name, string model, double speed, string type, double memoryVolume)
           : base(name, model)
        {
            Speed = speed;
            Type = type;
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
            Console.WriteLine("Тип: {}", Type);
            Console.WriteLine("Объем носителя: {0} Гб", MemoryVolume);
            Console.WriteLine("Свободный объем носителя: {0} ГБ", FreeMemoryVolume);
            Console.WriteLine("Скорость чтение/запись: {0} МБайт/с", Speed);
        }
    }
}
