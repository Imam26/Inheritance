using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    abstract class Storage
    {
        private string name;
        private string model;
        protected double FreeMemoryVolume { get; set; }
        public double Speed { get; set; }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Model
        {
            get => model;
            set =>model = value;
        }

        public Storage()
        {
            name = model = "default";
        }

        public Storage(string name, string model)
        {
            Name = name;
            Model = model;
        }

        public abstract double GetMemoryVolume();

        //Возвращает количество файлов которые не скопировались
        public abstract int CopyToStorage(int countOfFile, int sizeOfFile);

        public abstract double GetFreeMemoryVolume();

        public abstract void ShowInfoAboutStorage();
    }
}
